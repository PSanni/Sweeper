namespace FileShredder
{
    partial class Shredder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shredder));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFolderAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.CommonLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeSelectedTool = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.acionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startShreddingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.viewFilePropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Statustitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_count = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolFoderAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Fileid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fpath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mimetype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.acionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.MenuFolderAdd,
            this.CommonLoad,
            this.toolStripSeparator1,
            this.removeSelectedTool,
            this.removeAllTool,
            this.toolStripSeparator2,
            this.exitToolStrip});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.fileToolStripMenuItem.Text = "&Go";
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Image = global::FileShredder.Properties.Resources.document_new;
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addFilesToolStripMenuItem.Text = "Add file(s)";
            // 
            // MenuFolderAdd
            // 
            this.MenuFolderAdd.Image = global::FileShredder.Properties.Resources.tab_new;
            this.MenuFolderAdd.Name = "MenuFolderAdd";
            this.MenuFolderAdd.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.MenuFolderAdd.Size = new System.Drawing.Size(217, 22);
            this.MenuFolderAdd.Text = "Add folder(s)";
            this.MenuFolderAdd.Click += new System.EventHandler(this.MenuFolderAdd_Click);
            // 
            // CommonLoad
            // 
            this.CommonLoad.Name = "CommonLoad";
            this.CommonLoad.Size = new System.Drawing.Size(217, 22);
            this.CommonLoad.Text = "Recent loaded";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // removeSelectedTool
            // 
            this.removeSelectedTool.Image = global::FileShredder.Properties.Resources.erase;
            this.removeSelectedTool.Name = "removeSelectedTool";
            this.removeSelectedTool.Size = new System.Drawing.Size(217, 22);
            this.removeSelectedTool.Text = "Remove selected";
            this.removeSelectedTool.Click += new System.EventHandler(this.removeSelectedTool_Click);
            // 
            // removeAllTool
            // 
            this.removeAllTool.Name = "removeAllTool";
            this.removeAllTool.Size = new System.Drawing.Size(217, 22);
            this.removeAllTool.Text = "Remove all";
            this.removeAllTool.Click += new System.EventHandler(this.removeAllTool_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(214, 6);
            // 
            // exitToolStrip
            // 
            this.exitToolStrip.Image = global::FileShredder.Properties.Resources.close;
            this.exitToolStrip.Name = "exitToolStrip";
            this.exitToolStrip.Size = new System.Drawing.Size(217, 22);
            this.exitToolStrip.Text = "Exit";
            this.exitToolStrip.Click += new System.EventHandler(this.exitToolStrip_Click);
            // 
            // acionToolStripMenuItem
            // 
            this.acionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startShreddingToolStripMenuItem,
            this.toolStripSeparator4,
            this.viewFilePropertyToolStripMenuItem});
            this.acionToolStripMenuItem.Name = "acionToolStripMenuItem";
            this.acionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.acionToolStripMenuItem.Text = "&Action";
            // 
            // startShreddingToolStripMenuItem
            // 
            this.startShreddingToolStripMenuItem.Name = "startShreddingToolStripMenuItem";
            this.startShreddingToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.startShreddingToolStripMenuItem.Text = "Start Shredding";
            this.startShreddingToolStripMenuItem.Click += new System.EventHandler(this.startShreddingToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(236, 6);
            // 
            // viewFilePropertyToolStripMenuItem
            // 
            this.viewFilePropertyToolStripMenuItem.Name = "viewFilePropertyToolStripMenuItem";
            this.viewFilePropertyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.viewFilePropertyToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.viewFilePropertyToolStripMenuItem.Text = "View file property";
            this.viewFilePropertyToolStripMenuItem.Click += new System.EventHandler(this.viewFilePropertyToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Statustitle,
            this.StatusStatus,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.Status_count});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(766, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Statustitle
            // 
            this.Statustitle.Name = "Statustitle";
            this.Statustitle.Size = new System.Drawing.Size(45, 17);
            this.Statustitle.Text = "Status: ";
            // 
            // StatusStatus
            // 
            this.StatusStatus.Name = "StatusStatus";
            this.StatusStatus.Size = new System.Drawing.Size(26, 17);
            this.StatusStatus.Text = "Idel";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(624, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel2.Text = "Count:";
            // 
            // Status_count
            // 
            this.Status_count.Name = "Status_count";
            this.Status_count.Size = new System.Drawing.Size(13, 17);
            this.Status_count.Text = "0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.ToolFoderAdd,
            this.toolStripSeparator3,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(766, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.removeFileToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::FileShredder.Properties.Resources.gnome_document_new;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(62, 22);
            this.toolStripSplitButton1.Text = "Files";
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Image = global::FileShredder.Properties.Resources.document_new;
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addFileToolStripMenuItem.Text = "Add file";
            // 
            // removeFileToolStripMenuItem
            // 
            this.removeFileToolStripMenuItem.Image = global::FileShredder.Properties.Resources.erase;
            this.removeFileToolStripMenuItem.Name = "removeFileToolStripMenuItem";
            this.removeFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.removeFileToolStripMenuItem.Text = "Remove file";
            // 
            // ToolFoderAdd
            // 
            this.ToolFoderAdd.Image = global::FileShredder.Properties.Resources.tab_new;
            this.ToolFoderAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolFoderAdd.Name = "ToolFoderAdd";
            this.ToolFoderAdd.Size = new System.Drawing.Size(88, 22);
            this.ToolFoderAdd.Text = "Add folders";
            this.ToolFoderAdd.Click += new System.EventHandler(this.ToolFoderAdd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton3.Text = "Start";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Fileid,
            this.Fname,
            this.fpath,
            this.mimetype,
            this.FSize,
            this.FProgress,
            this.ext});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(766, 429);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Fileid
            // 
            this.Fileid.Text = "FileId";
            // 
            // Fname
            // 
            this.Fname.Text = "Filename";
            this.Fname.Width = 120;
            // 
            // fpath
            // 
            this.fpath.Text = "Path";
            this.fpath.Width = 250;
            // 
            // mimetype
            // 
            this.mimetype.Text = "File type";
            this.mimetype.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mimetype.Width = 100;
            // 
            // FSize
            // 
            this.FSize.Text = "Size";
            this.FSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FSize.Width = 100;
            // 
            // FProgress
            // 
            this.FProgress.Text = "Progress";
            this.FProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ext
            // 
            this.ext.Text = "Extension";
            this.ext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ext.Width = 80;
            // 
            // FileDialog1
            // 
            this.FileDialog1.FileName = "openFileDialog1";
            // 
            // Shredder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 500);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Shredder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shredder ";
            this.Load += new System.EventHandler(this.Shredder_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acionToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuFolderAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedTool;
        private System.Windows.Forms.ToolStripMenuItem removeAllTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStrip;
        private System.Windows.Forms.ToolStripMenuItem startShreddingToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton ToolFoderAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ColumnHeader Fileid;
        private System.Windows.Forms.ColumnHeader Fname;
        private System.Windows.Forms.ColumnHeader fpath;
        private System.Windows.Forms.ColumnHeader FSize;
        private System.Windows.Forms.ColumnHeader FProgress;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel Statustitle;
        private System.Windows.Forms.OpenFileDialog FileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderDialog1;
        private System.Windows.Forms.ColumnHeader mimetype;
        private System.Windows.Forms.ToolStripStatusLabel StatusStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel Status_count;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem viewFilePropertyToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader ext;
        private System.Windows.Forms.ToolStripMenuItem CommonLoad;





    }
}

