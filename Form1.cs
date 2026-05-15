using winFormTestSauron.Core;
using System.IO;
using winFormTestSauron.Plugins;
using System.Diagnostics;
using winFormTestSauron.Interfaces;

namespace winFormTestSauron
{
    public partial class Form1 : Form
    {
        private FileOperationsManager _FileOpManager = new FileOperationsManager();
        private PluginLoader _PluginLoader = new PluginLoader();
        private IThemeManager _themeManager;

        public Form1()
        {
            InitializeComponent();

            _themeManager = new Theme(this);

            DefaultTheme();

            _themeManager.ApplyTheme();
        }

        #region Show Folders/Files

        private void AdjustColumnSizes()
        {
            int totalWidth = filesListView.ClientSize.Width;
            if (totalWidth > 0)
            {
                //must have a total of 100%
                filesListView.Columns[0].Width = (int)(totalWidth * 0.55); // File Name (50%)
                filesListView.Columns[1].Width = (int)(totalWidth * 0.10); // Size (15%)
                filesListView.Columns[2].Width = (int)(totalWidth * 0.20); // Last-edit (20%)
                filesListView.Columns[3].Width = (int)(totalWidth * 0.15); // Extensions (15%)
            }
        }

        private void listView1_Resize_1(object sender, EventArgs e)
        {
            AdjustColumnSizes();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            diskTreeView.BeginUpdate();

            string[] disks = _FileOpManager.GetDisk();

            foreach (string a in disks)
            {
                TreeNode _treeNode = new TreeNode(a);
                diskTreeView.Nodes.Add(_treeNode);
                DirectoryInfo[] dirs = _FileOpManager.AddDirs(a);

                foreach (DirectoryInfo directory in dirs)
                {
                    TreeNode treeDir = new TreeNode(directory.Name);
                    _treeNode.Nodes.Add(treeDir);

                }
            }
            diskTreeView.EndUpdate();
            AdjustColumnSizes();
        }

        private void diskTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(diskTreeView.SelectedNode.FullPath);
            FileInfo[] Files = { };

            filesListView.Items.Clear();

            if (diskTreeView.SelectedNode == null) return;

            try
            {
                Files = _FileOpManager.ShowFileNames(info);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Accès refusé à ce dossier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
                return;
            }

            filesListView.BeginUpdate();

            foreach (FileInfo file in Files)
            {
                ListViewItem item = new ListViewItem(file.Name);

                string weight = _FileOpManager.FileSizeCalculator(file.Length);

                item.SubItems.Add(weight);
                item.SubItems.Add(file.LastWriteTime.ToShortDateString());
                item.SubItems.Add(file.Extension);

                filesListView.Items.Add(item);
            }
            filesListView.EndUpdate();
            filePathLabel.Text = diskTreeView.SelectedNode.FullPath;
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            diskTreeView.BeginUpdate();

            foreach (TreeNode tree in e.Node.Nodes)
            {
                DirectoryInfo[] dirs = _FileOpManager.AddDirs(tree.FullPath);

                foreach (DirectoryInfo directory in dirs)
                {
                    TreeNode treeDir = new TreeNode(directory.Name);
                    tree.Nodes.Add(treeDir);

                }
            }
            diskTreeView.EndUpdate();
        }
        #endregion

        #region Open Files

        private void Open_Click(object sender, EventArgs e)
        {

            listView1_MouseDoubleClick(sender, null);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem ItemUnderMouse = filesListView.GetItemAt(e.X, e.Y);

                if (ItemUnderMouse != null)
                {
                    ItemUnderMouse.Selected = true;
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string path = Path.Combine(diskTreeView.SelectedNode.FullPath, filesListView.SelectedItems[0].Text);
                Console.WriteLine(path);
                _FileOpManager.OpenFile(path);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible d'ouvrir le fichier");
            }
        }

        #endregion

        #region Rename Files
        private void Rename_Click(object sender, EventArgs e)
        {
            if (filesListView.SelectedItems.Count > 0)
            {
                filesListView.SelectedItems[0].BeginEdit();
            }
        }
        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                string CurrentPath = diskTreeView.SelectedNode.FullPath;
                string OldName = filesListView.SelectedItems[0].Text;
                string OldPath = Path.Combine(CurrentPath, OldName);
                bool success = _FileOpManager.RenameFile(OldPath, e.Label);
                if (!success) e.CancelEdit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible to rename this file");
            }
        }

        #endregion

        #region Delete Files
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                // DialogBox de confirmation pour la suppression d'un fichier
                DialogResult dialogResult = MessageBox.Show("Are you reaaally sure ?", "ANNIHILATION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (filesListView.SelectedItems.Count > 0 && DialogResult.Yes == dialogResult)
                {
                    string FileName = filesListView.SelectedItems[0].Text;
                    string path = diskTreeView.SelectedNode.FullPath;
                    string Filepath = Path.Combine(path, FileName);
                    bool success = _FileOpManager.DeleteFile(Filepath);
                    if (success) filesListView.SelectedItems[0].Remove();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible to delete this file");
            }
        }
        #endregion

        #region Create Files
        private void create_Click(object sender, EventArgs e)
        {
            try
            {
                string DefaultFileName = "New File.txt";
                string path = Path.Combine(diskTreeView.SelectedNode.FullPath, DefaultFileName);

                bool success = _FileOpManager.CreateFile(path);
                if (success)
                {
                    ListViewItem NewFile = new ListViewItem(DefaultFileName);

                    NewFile.SubItems.Add(" 0 B");
                    NewFile.SubItems.Add(DateTime.Now.ToShortDateString());
                    NewFile.SubItems.Add(" .txt");

                    filesListView.Items.Add(NewFile);

                    NewFile.Selected = true;
                    NewFile.BeginEdit(); // pour lancer le renommage
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible to create this file");
            }
        }
        #endregion

        #region Refresh 
        private void refreshButton_Click(object sender, EventArgs e)
        {
            diskTreeView_AfterSelect(sender, null);
        }
        #endregion

        #region Options
        private void optionsButton_Click(object sender, EventArgs e) //WIP
        {
            contextMenuOptions.Show(optionsButton, new Point(0, optionsButton.Height));
        }
        #endregion Options

        #region Themes


        private void DefaultTheme()
        {
            _themeManager.BackgroundColor = Color.FromArgb(236, 239, 244);
            _themeManager.SurfaceColor = Color.White;
            _themeManager.TextColor = Color.FromArgb(46, 52, 64);
            _themeManager.AccentColor = Color.FromArgb(136, 192, 208);
            _themeManager.FontName = "Segoe UI";
        }
        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _themeManager.BackgroundColor = Color.FromArgb(30, 30, 30);
            _themeManager.SurfaceColor = Color.FromArgb(45, 45, 48);
            _themeManager.TextColor = Color.WhiteSmoke;
            _themeManager.AccentColor = Color.SteelBlue;
            _themeManager.FontName = "Segoe UI";

            _themeManager.ApplyTheme();
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _themeManager.BackgroundColor = Color.FromArgb(236, 239, 244);
            _themeManager.SurfaceColor = Color.White;
            _themeManager.TextColor = Color.FromArgb(46, 52, 64);
            _themeManager.AccentColor = Color.FromArgb(136, 192, 208);
            _themeManager.FontName = "Segoe UI";

            _themeManager.ApplyTheme();
        }

        private void cyberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _themeManager.BackgroundColor = Color.FromArgb(10, 10, 15);
            _themeManager.SurfaceColor = Color.FromArgb(20, 20, 30);
            _themeManager.TextColor = Color.FromArgb(0, 255, 150);
            _themeManager.AccentColor = Color.MediumPurple;
            _themeManager.FontName = "Consolas";

            _themeManager.ApplyTheme();
        }

        private void forestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _themeManager.BackgroundColor = Color.FromArgb(20, 25, 20);
            _themeManager.SurfaceColor = Color.FromArgb(35, 45, 35);
            _themeManager.TextColor = Color.FromArgb(210, 225, 200);
            _themeManager.AccentColor = Color.OrangeRed;
            _themeManager.FontName = "Trebuchet MS";

            _themeManager.ApplyTheme();
        }

        private void oceanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _themeManager.BackgroundColor = Color.FromArgb(38, 50, 56);
            _themeManager.SurfaceColor = Color.FromArgb(55, 71, 79);
            _themeManager.TextColor = Color.White;
            _themeManager.AccentColor = Color.FromArgb(128, 203, 196);
            _themeManager.FontName = "Verdana";

            _themeManager.ApplyTheme();
        }

        #endregion Themes

        #region Plugin
        private void OpenAIPluginStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IPlugin? existing = _PluginLoader.Get("OpenAIPlugin");

                if (existing == null)
                {
                    _PluginLoader.Load(new OpenAIPlugin());
                    MessageBox.Show("OpenAI plugin chargé.", "Plugin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Afficher le panneau de chat (le designer a créé panelChat mais ne l'a pas ajouté aux Controls)
                if (!this.Controls.Contains(panelChat))
                {
                    // Ajouter le panneau de chat à la Form
                    this.Controls.Add(panelChat);
                }
                panelChat.Visible = true;
                panelChat.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du plugin : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnAgentAI_Click(object sender, EventArgs e)
        {
            try
            {
                string question = txtInput.Text.Trim();
                if (string.IsNullOrEmpty(question)) return;

                btnAgentAI.Enabled = false;
                txtInput.Clear();

                IPlugin? plugin = _PluginLoader.Get("OpenAIPlugin");

                if (plugin == null) return;
                string response = await plugin.ExecuteCallAsync(question);

                txtConversation.AppendText("Sauron : " + response + "\r\n\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                btnAgentAI.Enabled = true;
            }
        }

        private void btn_GitHub_Click(object sender, EventArgs e)
        {
            try
            {
                string _url = "https://github.com/";
                _FileOpManager.OuvrirURL(_url);
            }
            catch
            {
                MessageBox.Show("Impossible d'ouvrir le site ");
            }
        }
        #endregion

    }
}
