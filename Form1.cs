using winFormTestSauron.Core;
using System.IO;

namespace winFormTestSauron
{
    public partial class Form1 : Form
    {
        private FileOperationsManager FileOpManager = new FileOperationsManager();

        public Form1()
        {
            InitializeComponent();
        }
        #region Show Folders/Files

        public void Form1_Load(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();

            string[] disks = FileOpManager.GetDisk();

            foreach (string a in disks)
            {
                TreeNode _treeNode = new TreeNode(a);
                treeView1.Nodes.Add(_treeNode);
                DirectoryInfo[] dirs = FileOpManager.AddDirs(a);

                foreach (DirectoryInfo directory in dirs)
                {
                    TreeNode treeDir = new TreeNode(directory.Name);
                    _treeNode.Nodes.Add(treeDir);

                }
            }
            treeView1.EndUpdate();
        }

        public void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(treeView1.SelectedNode.FullPath);
            FileInfo[] Files = { };

            listView1.Items.Clear();

            if (treeView1.SelectedNode == null) return;

            try
            {
                Files = FileOpManager.ShowFileNames(info);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Accès refusé à ce dossier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }  

            listView1.BeginUpdate();

            foreach (FileInfo file in Files)
            {
                ListViewItem item = new ListViewItem(file.Name);

                string weight = FileOpManager.FileSizeCalculator(file.Length);

                item.SubItems.Add(weight);
                item.SubItems.Add(file.LastWriteTime.ToShortDateString());
                item.SubItems.Add(file.Extension);

                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }
        
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();

            foreach (TreeNode tree in e.Node.Nodes)
            {
                DirectoryInfo[] dirs = FileOpManager.AddDirs(tree.FullPath);

                foreach (DirectoryInfo directory in dirs)
                {
                    TreeNode treeDir = new TreeNode(directory.Name);
                    tree.Nodes.Add(treeDir);

                }
            }
            treeView1.EndUpdate();
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
                ListViewItem ItemUnderMouse = listView1.GetItemAt(e.X, e.Y);

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
                string path = Path.Combine(treeView1.SelectedNode.FullPath, listView1.SelectedItems[0].Text);
                Console.WriteLine(path);
                FileOpManager.OpenFile(path);

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
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].BeginEdit();
            }
        }
        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                string CurrentPath = treeView1.SelectedNode.FullPath;
                string OldName = listView1.SelectedItems[0].Text;
                string OldPath = Path.Combine(CurrentPath, OldName);
                bool success = FileOpManager.RenameFile(OldPath, e.Label);
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

                if (listView1.SelectedItems.Count > 0 && DialogResult.Yes == dialogResult)
                {
                    string FileName = listView1.SelectedItems[0].Text;
                    string path = treeView1.SelectedNode.FullPath;
                    string Filepath = Path.Combine(path, FileName);
                    bool success = FileOpManager.DeleteFile(Filepath);
                    if (success) listView1.SelectedItems[0].Remove();

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
                string path = Path.Combine(treeView1.SelectedNode.FullPath, DefaultFileName);

                bool success = FileOpManager.CreateFile(path);
                if (success)
                {
                    ListViewItem NewFile = new ListViewItem(DefaultFileName);

                    NewFile.SubItems.Add(" 0 B");
                    NewFile.SubItems.Add(DateTime.Now.ToShortDateString());
                    NewFile.SubItems.Add(" .txt");

                    listView1.Items.Add(NewFile);

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
            DirectoryInfo info = new DirectoryInfo(treeView1.SelectedNode.FullPath);
            FileInfo[] Files = { };

            listView1.Items.Clear();

            try
            {
                Files = FileOpManager.ShowFileNames(info);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Accès refusé à ce dossier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du rafraîchissement : " + ex.Message);
                return;
            }

            listView1.BeginUpdate();

            foreach (FileInfo file in Files)
            {
                ListViewItem item = new ListViewItem(file.Name);

                string weight = FileOpManager.FileSizeCalculator(file.Length);

                item.SubItems.Add(weight);
                item.SubItems.Add(file.LastWriteTime.ToShortDateString());
                item.SubItems.Add(file.Extension);

                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
            
        }
        #endregion
    }
}
