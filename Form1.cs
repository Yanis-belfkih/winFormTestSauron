using winFormTestSauron.Core;

namespace winFormTestSauron
{
    public partial class Form1 : Form
    {
        private FileOperationsManager FileOpManager = new FileOperationsManager();

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();

            string[] disks = FileOpManager.ShowDisk();

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
            FileInfo[] Files = {};

            listView1.Items.Clear();
            if (treeView1.SelectedNode == null) return;

            try{
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
            
            if (Files != null)
            {
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
        // private void listView1_DoubleClick(object sender, EventArgs e)
        // {
        //     FileOpManager.OpenFile();
        // }
    }
}
