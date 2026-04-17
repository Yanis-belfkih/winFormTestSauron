namespace winFormTestSauron
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e)
        {

            ShowDisk();
        }

        public void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowFileNames();
        }


        private void ShowDisk()
        {
            treeView1.BeginUpdate();

            string[] disks = Directory.GetLogicalDrives();

            foreach (string a in disks)
            {
                TreeNode _treeNode = new TreeNode(a);
                treeView1.Nodes.Add(_treeNode);
                AddDirs(_treeNode);
            }
            treeView1.EndUpdate();
        }
        public void ShowFileNames()
        {
            DirectoryInfo info = new DirectoryInfo(treeView1.SelectedNode.FullPath);
            FileInfo[] Files = { };
            ListViewItem item;

            listView1.Items.Clear();

            if (info != null)
            {
                Files = info.GetFiles();
            }

            listView1.BeginUpdate();
            foreach (FileInfo file in Files)
            {
                item = new ListViewItem(file.Name);
                listView1.Items.Add(item);

            }
            listView1.EndUpdate();

        }

        public void AddDirs(TreeNode tree)
        {
            string path = tree.FullPath;

            DirectoryInfo info = new DirectoryInfo(path);
            DirectoryInfo[] dir = { };

            if (info != null)
            {
                dir = info.GetDirectories();
            }

            foreach (DirectoryInfo directory in dir)
            {
                TreeNode treeDir = new TreeNode(directory.Name);
                tree.Nodes.Add(treeDir);

            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();

            foreach(TreeNode tree in e.Node.Nodes)
            {
                AddDirs(tree);
            }
            treeView1.EndUpdate();
        }
    }
}
