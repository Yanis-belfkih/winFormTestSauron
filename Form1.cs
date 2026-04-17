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
            // 1. Vérification de sécurité pour le noeud sélectionné
            if (treeView1.SelectedNode == null) return;

            DirectoryInfo info = new DirectoryInfo(treeView1.SelectedNode.FullPath);
            FileInfo[] Files = null; // Initialisé à null

            listView1.Items.Clear();

            try
            {
                // 2. On tente de récupérer les fichiers
                if (info.Exists)
                {
                    Files = info.GetFiles();
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Si l'accès est refusé, on affiche un message ou on laisse la liste vide
                MessageBox.Show("Accès refusé à ce dossier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
                return;
            }

            // 3. Remplissage de la ListView
            if (Files != null)
            {
                listView1.BeginUpdate();
                foreach (FileInfo file in Files)
                {
                    // Colonne 1 : Le nom
                    ListViewItem item = new ListViewItem(file.Name);

                    // Colonne 2 : La taille (convertie en KB pour plus de lisibilité)
                    long sizeInKb = file.Length / 1024;
                    double modularsize;

                    if (sizeInKb <= 1000)
                    {
                        modularsize = sizeInKb;
                        item.SubItems.Add(modularsize.ToString() + " KB");
                    }
                    else if (sizeInKb >= 1000)
                    {
                        modularsize = sizeInKb / 1000;
                        item.SubItems.Add(modularsize.ToString() + " MB");
                    }
                    else if (sizeInKb >= 1000000) 
                    {
                        modularsize = sizeInKb / 1000000;
                        item.SubItems.Add(modularsize.ToString() + " GB");
                    }

                    // Colonne 3 : La date
                    item.SubItems.Add(file.LastWriteTime.ToShortDateString());

                    // Colonne 4 : extension
                    item.SubItems.Add(file.Extension);

                    listView1.Items.Add(item);
                }
                listView1.EndUpdate();
            }
        }

        public void AddDirs(TreeNode tree)
        {
            string path = tree.FullPath;

            DirectoryInfo info = new DirectoryInfo(path);
            DirectoryInfo[] dir = { };

            try
            {
                if (info != null)
                {
                    dir = info.GetDirectories();
                }
            }
            catch (UnauthorizedAccessException)
            {
                // On ignore le dossier si l'accès est refusé
                dir = new DirectoryInfo[0];
            }
            catch (Exception ex)
            {
                // Pour gérer d'autres erreurs éventuelles
                Console.WriteLine("Erreur : " + ex.Message);
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

            foreach (TreeNode tree in e.Node.Nodes)
            {
                AddDirs(tree);
            }
            treeView1.EndUpdate();
        }
    }
}
