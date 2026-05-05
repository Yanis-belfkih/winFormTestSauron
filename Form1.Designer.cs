namespace winFormTestSauron
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            diskTreeView = new TreeView();
            filesListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            Open = new ToolStripMenuItem();
            Rename = new ToolStripMenuItem();
            Delete = new ToolStripMenuItem();
            create = new ToolStripMenuItem();
            refreshButton = new Button();
            panel1 = new Panel();
            filePathLabel = new Label();
            optionsButton = new Button();
            contextMenuOptions = new ContextMenuStrip(components);
            pluginsToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            darkToolStripMenuItem = new ToolStripMenuItem();
            lightToolStripMenuItem = new ToolStripMenuItem();
            CyberToolStripMenuItem = new ToolStripMenuItem();
            forestToolStripMenuItem = new ToolStripMenuItem();
            oceanToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            contextMenuOptions.SuspendLayout();
            SuspendLayout();
            // 
            // diskTreeView
            // 
            diskTreeView.Dock = DockStyle.Left;
            diskTreeView.Location = new Point(0, 43);
            diskTreeView.Margin = new Padding(2, 1, 2, 1);
            diskTreeView.Name = "diskTreeView";
            diskTreeView.Size = new Size(193, 456);
            diskTreeView.TabIndex = 0;
            diskTreeView.BeforeExpand += treeView1_BeforeExpand;
            diskTreeView.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // filesListView
            // 
            filesListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            filesListView.ContextMenuStrip = contextMenuStrip1;
            filesListView.Dock = DockStyle.Fill;
            filesListView.LabelEdit = true;
            filesListView.Location = new Point(193, 43);
            filesListView.Margin = new Padding(2, 1, 2, 1);
            filesListView.Name = "filesListView";
            filesListView.Size = new Size(831, 456);
            filesListView.TabIndex = 1;
            filesListView.UseCompatibleStateImageBehavior = false;
            filesListView.View = View.Details;
            filesListView.AfterLabelEdit += listView1_AfterLabelEdit;
            filesListView.MouseClick += listView1_MouseClick;
            filesListView.MouseDoubleClick += listView1_MouseDoubleClick;
            filesListView.Resize += listView1_Resize_1;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "File Name";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Size";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Last-edit";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "extentions";
            columnHeader4.Width = 100;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { Open, Rename, Delete, create });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(118, 92);
            // 
            // Open
            // 
            Open.Name = "Open";
            Open.Size = new Size(117, 22);
            Open.Text = "Open";
            Open.Click += Open_Click;
            // 
            // Rename
            // 
            Rename.Name = "Rename";
            Rename.Size = new Size(117, 22);
            Rename.Text = "Rename";
            Rename.Click += Rename_Click;
            // 
            // Delete
            // 
            Delete.Name = "Delete";
            Delete.Size = new Size(117, 22);
            Delete.Text = "Delete";
            Delete.Click += Delete_Click;
            // 
            // create
            // 
            create.Name = "create";
            create.Size = new Size(117, 22);
            create.Text = "Create ";
            create.Click += create_Click;
            // 
            // refreshButton
            // 
            refreshButton.Dock = DockStyle.Right;
            refreshButton.Location = new Point(943, 0);
            refreshButton.Margin = new Padding(2, 1, 2, 1);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(81, 43);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(filePathLabel);
            panel1.Controls.Add(optionsButton);
            panel1.Controls.Add(refreshButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1024, 43);
            panel1.TabIndex = 4;
            // 
            // filePathLabel
            // 
            filePathLabel.BackColor = Color.IndianRed;
            filePathLabel.BorderStyle = BorderStyle.Fixed3D;
            filePathLabel.Dock = DockStyle.Fill;
            filePathLabel.Location = new Point(0, 0);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Padding = new Padding(25, 0, 0, 0);
            filePathLabel.Size = new Size(868, 43);
            filePathLabel.TabIndex = 0;
            filePathLabel.Text = "Please add the filepath to this label";
            filePathLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // optionsButton
            // 
            optionsButton.Dock = DockStyle.Right;
            optionsButton.Location = new Point(868, 0);
            optionsButton.Name = "optionsButton";
            optionsButton.Size = new Size(75, 43);
            optionsButton.TabIndex = 4;
            optionsButton.Text = "Options";
            optionsButton.UseVisualStyleBackColor = true;
            optionsButton.Click += optionsButton_Click;
            // 
            // contextMenuOptions
            // 
            contextMenuOptions.Items.AddRange(new ToolStripItem[] { pluginsToolStripMenuItem, themeToolStripMenuItem });
            contextMenuOptions.Name = "contextMenuOptions";
            contextMenuOptions.Size = new Size(114, 48);
            // 
            // pluginsToolStripMenuItem
            // 
            pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            pluginsToolStripMenuItem.Size = new Size(113, 22);
            pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkToolStripMenuItem, lightToolStripMenuItem, CyberToolStripMenuItem, forestToolStripMenuItem, oceanToolStripMenuItem });
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(113, 22);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // darkToolStripMenuItem
            // 
            darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            darkToolStripMenuItem.Size = new Size(108, 22);
            darkToolStripMenuItem.Text = "Dark";
            darkToolStripMenuItem.Click += darkToolStripMenuItem_Click;
            // 
            // lightToolStripMenuItem
            // 
            lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            lightToolStripMenuItem.Size = new Size(108, 22);
            lightToolStripMenuItem.Text = "Light";
            lightToolStripMenuItem.Click += lightToolStripMenuItem_Click;
            // 
            // CyberToolStripMenuItem
            // 
            CyberToolStripMenuItem.Name = "CyberToolStripMenuItem";
            CyberToolStripMenuItem.Size = new Size(108, 22);
            CyberToolStripMenuItem.Text = "Cyber";
            CyberToolStripMenuItem.Click += cyberToolStripMenuItem_Click;
            // 
            // forestToolStripMenuItem
            // 
            forestToolStripMenuItem.Name = "forestToolStripMenuItem";
            forestToolStripMenuItem.Size = new Size(108, 22);
            forestToolStripMenuItem.Text = "Forest";
            forestToolStripMenuItem.Click += forestToolStripMenuItem_Click;
            // 
            // oceanToolStripMenuItem
            // 
            oceanToolStripMenuItem.Name = "oceanToolStripMenuItem";
            oceanToolStripMenuItem.Size = new Size(108, 22);
            oceanToolStripMenuItem.Text = "Ocean";
            oceanToolStripMenuItem.Click += oceanToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 499);
            Controls.Add(filesListView);
            Controls.Add(diskTreeView);
            Controls.Add(panel1);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            contextMenuOptions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public TreeView diskTreeView;
        public ListView filesListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem Open;
        private ToolStripMenuItem Rename;
        private ToolStripMenuItem Delete;
        private ToolStripMenuItem create;
        private Button refreshButton;
        private Panel panel1;
        public Label filePathLabel;
        private Button optionsButton;
        public ContextMenuStrip contextMenuOptions;
        private ToolStripMenuItem pluginsToolStripMenuItem;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem darkToolStripMenuItem;
        private ToolStripMenuItem lightToolStripMenuItem;
        private ToolStripMenuItem CyberToolStripMenuItem;
        private ToolStripMenuItem forestToolStripMenuItem;
        private ToolStripMenuItem oceanToolStripMenuItem;
    }
}
