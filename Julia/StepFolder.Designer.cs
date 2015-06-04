namespace Julia
{
    partial class StepFolder
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
            this.filelist = new Julia.ListViewExtended();
            this.colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taglist = new Julia.ListViewExtended();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // filelist
            // 
            this.filelist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filelist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFile});
            this.filelist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filelist.FullRowSelect = true;
            this.filelist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.filelist.Location = new System.Drawing.Point(642, -1);
            this.filelist.MultiSelect = false;
            this.filelist.Name = "filelist";
            this.filelist.OwnerDraw = true;
            this.filelist.SingleColumn = false;
            this.filelist.Size = new System.Drawing.Size(146, 395);
            this.filelist.TabIndex = 0;
            this.filelist.UseCompatibleStateImageBehavior = false;
            this.filelist.View = System.Windows.Forms.View.Details;
            this.filelist.SelectedIndexChanged += new System.EventHandler(this.filelist_SelectedIndexChanged);
            // 
            // colFile
            // 
            this.colFile.Text = "File";
            // 
            // taglist
            // 
            this.taglist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.taglist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.taglist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taglist.FullRowSelect = true;
            this.taglist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.taglist.Location = new System.Drawing.Point(-1, -1);
            this.taglist.MultiSelect = false;
            this.taglist.Name = "taglist";
            this.taglist.OwnerDraw = true;
            this.taglist.SingleColumn = false;
            this.taglist.Size = new System.Drawing.Size(146, 395);
            this.taglist.TabIndex = 0;
            this.taglist.UseCompatibleStateImageBehavior = false;
            this.taglist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            // 
            // img
            // 
            this.img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img.BackColor = System.Drawing.SystemColors.Window;
            this.img.Location = new System.Drawing.Point(144, -1);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(499, 395);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img.TabIndex = 1;
            this.img.TabStop = false;
            // 
            // StepFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 393);
            this.Controls.Add(this.taglist);
            this.Controls.Add(this.filelist);
            this.Controls.Add(this.img);
            this.Name = "StepFolder";
            this.ShowIcon = false;
            this.Text = "Step folder - Null";
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewExtended filelist;
        private System.Windows.Forms.ColumnHeader colFile;
        private ListViewExtended taglist;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.PictureBox img;
    }
}