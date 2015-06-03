namespace Julia
{
    partial class Main
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.list = new Julia.ListViewExtended();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuFileTag = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileImportText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileImportDb = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExportText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExportDb = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditEngrave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActionSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuAction});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(613, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "Menu";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileTag,
            this.toolStripSeparator1,
            this.menuFileImport,
            this.menuFileExport});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditEdit,
            this.menuEditEngrave,
            this.toolStripSeparator2,
            this.menuEditRemove});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "Edit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // menuAction
            // 
            this.menuAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuActionSearch});
            this.menuAction.Name = "menuAction";
            this.menuAction.Size = new System.Drawing.Size(54, 20);
            this.menuAction.Text = "Action";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(122, 6);
            // 
            // list
            // 
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPath,
            this.colTags});
            this.list.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.FullRowSelect = true;
            this.list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list.Location = new System.Drawing.Point(-1, 24);
            this.list.Name = "list";
            this.list.OwnerDraw = true;
            this.list.SingleColumn = false;
            this.list.Size = new System.Drawing.Size(615, 400);
            this.list.TabIndex = 1;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Details;
            this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 120;
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 357;
            // 
            // colTags
            // 
            this.colTags.Text = "Tags";
            this.colTags.Width = 133;
            // 
            // menuFileTag
            // 
            this.menuFileTag.Image = global::Julia.Properties.Resources.tag_blue;
            this.menuFileTag.Name = "menuFileTag";
            this.menuFileTag.Size = new System.Drawing.Size(122, 22);
            this.menuFileTag.Text = "Tag file...";
            // 
            // menuFileImport
            // 
            this.menuFileImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileImportText,
            this.menuFileImportDb});
            this.menuFileImport.Image = global::Julia.Properties.Resources.arrow_down;
            this.menuFileImport.Name = "menuFileImport";
            this.menuFileImport.Size = new System.Drawing.Size(122, 22);
            this.menuFileImport.Text = "Import...";
            // 
            // menuFileImportText
            // 
            this.menuFileImportText.Image = global::Julia.Properties.Resources.page_white_text;
            this.menuFileImportText.Name = "menuFileImportText";
            this.menuFileImportText.Size = new System.Drawing.Size(122, 22);
            this.menuFileImportText.Text = "Text";
            // 
            // menuFileImportDb
            // 
            this.menuFileImportDb.Image = global::Julia.Properties.Resources.database;
            this.menuFileImportDb.Name = "menuFileImportDb";
            this.menuFileImportDb.Size = new System.Drawing.Size(122, 22);
            this.menuFileImportDb.Text = "Database";
            // 
            // menuFileExport
            // 
            this.menuFileExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileExportText,
            this.menuFileExportDb});
            this.menuFileExport.Image = global::Julia.Properties.Resources.disk;
            this.menuFileExport.Name = "menuFileExport";
            this.menuFileExport.Size = new System.Drawing.Size(122, 22);
            this.menuFileExport.Text = "Export...";
            // 
            // menuFileExportText
            // 
            this.menuFileExportText.Image = global::Julia.Properties.Resources.page_white_text;
            this.menuFileExportText.Name = "menuFileExportText";
            this.menuFileExportText.Size = new System.Drawing.Size(122, 22);
            this.menuFileExportText.Text = "Text";
            // 
            // menuFileExportDb
            // 
            this.menuFileExportDb.Image = global::Julia.Properties.Resources.database;
            this.menuFileExportDb.Name = "menuFileExportDb";
            this.menuFileExportDb.Size = new System.Drawing.Size(122, 22);
            this.menuFileExportDb.Text = "Database";
            // 
            // menuEditEdit
            // 
            this.menuEditEdit.Enabled = false;
            this.menuEditEdit.Image = global::Julia.Properties.Resources.pencil;
            this.menuEditEdit.Name = "menuEditEdit";
            this.menuEditEdit.Size = new System.Drawing.Size(125, 22);
            this.menuEditEdit.Text = "Edit item";
            // 
            // menuEditEngrave
            // 
            this.menuEditEngrave.Enabled = false;
            this.menuEditEngrave.Image = global::Julia.Properties.Resources.page_white_edit;
            this.menuEditEngrave.Name = "menuEditEngrave";
            this.menuEditEngrave.Size = new System.Drawing.Size(125, 22);
            this.menuEditEngrave.Text = "Engrave...";
            // 
            // menuEditRemove
            // 
            this.menuEditRemove.Enabled = false;
            this.menuEditRemove.Image = global::Julia.Properties.Resources.cross;
            this.menuEditRemove.Name = "menuEditRemove";
            this.menuEditRemove.Size = new System.Drawing.Size(125, 22);
            this.menuEditRemove.Text = "Remove";
            this.menuEditRemove.Click += new System.EventHandler(this.menuEditRemove_Click);
            // 
            // menuActionSearch
            // 
            this.menuActionSearch.Image = global::Julia.Properties.Resources.magnifier;
            this.menuActionSearch.Name = "menuActionSearch";
            this.menuActionSearch.Size = new System.Drawing.Size(109, 22);
            this.menuActionSearch.Text = "Search";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(613, 423);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.list);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Julia";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileImport;
        private System.Windows.Forms.ToolStripMenuItem menuFileExport;
        private System.Windows.Forms.ToolStripMenuItem menuFileImportText;
        private System.Windows.Forms.ToolStripMenuItem menuFileImportDb;
        private System.Windows.Forms.ToolStripMenuItem menuFileExportText;
        private System.Windows.Forms.ToolStripMenuItem menuFileExportDb;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuEditEdit;
        private System.Windows.Forms.ToolStripMenuItem menuEditEngrave;
        private System.Windows.Forms.ToolStripMenuItem menuFileTag;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuAction;
        private System.Windows.Forms.ToolStripMenuItem menuActionSearch;
        private ListViewExtended list;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ColumnHeader colTags;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuEditRemove;
    }
}

