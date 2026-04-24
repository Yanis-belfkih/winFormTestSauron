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
            treeView1 = new TreeView();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            Open = new ToolStripMenuItem();
            Rename = new ToolStripMenuItem();
            Delete = new ToolStripMenuItem();
            create = new ToolStripMenuItem();
            splitter1 = new Splitter();
            refreshButton = new Button();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Left;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(420, 966);
            treeView1.TabIndex = 0;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Dock = DockStyle.Fill;
            listView1.LabelEdit = true;
            listView1.Location = new Point(420, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(1462, 966);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.AfterLabelEdit += listView1_AfterLabelEdit;
            listView1.MouseClick += listView1_MouseClick;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "File Name";
            columnHeader1.Width = 500;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Size";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Last-edit";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "extentions";
            columnHeader4.Width = 200;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { Open, Rename, Delete, create });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(175, 156);
            // 
            // Open
            // 
            Open.Name = "Open";
            Open.Size = new Size(174, 38);
            Open.Text = "Open";
            Open.Click += Open_Click;
            // 
            // Rename
            // 
            Rename.Name = "Rename";
            Rename.Size = new Size(174, 38);
            Rename.Text = "Rename";
            Rename.Click += Rename_Click;
            // 
            // Delete
            // 
            Delete.Name = "Delete";
            Delete.Size = new Size(174, 38);
            Delete.Text = "Delete";
            Delete.Click += Delete_Click;
            // 
            // create
            // 
            create.Name = "create";
            create.Size = new Size(174, 38);
            create.Text = "Create ";
            create.Click += create_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(420, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(6, 966);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(1720, 12);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(150, 46);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1882, 966);
            Controls.Add(refreshButton);
            Controls.Add(splitter1);
            Controls.Add(listView1);
            Controls.Add(treeView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private Splitter splitter1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem Open;
        private ToolStripMenuItem Rename;
        private ToolStripMenuItem Delete;
        private ToolStripMenuItem create;
        private Button refreshButton;
    }
}
