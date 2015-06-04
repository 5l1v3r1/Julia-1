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
            this.filelist.Location = new System.Drawing.Point(492, -1);
            this.filelist.MultiSelect = false;
            this.filelist.Name = "filelist";
            this.filelist.OwnerDraw = true;
            this.filelist.SingleColumn = false;
            this.filelist.Size = new System.Drawing.Size(146, 376);
            this.filelist.TabIndex = 0;
            this.filelist.UseCompatibleStateImageBehavior = false;
            this.filelist.View = System.Windows.Forms.View.Details;
            // 
            // colFile
            // 
            this.colFile.Text = "File";
            // 
            // StepFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 374);
            this.Controls.Add(this.filelist);
            this.Name = "StepFolder";
            this.ShowIcon = false;
            this.Text = "Step folder - Null";
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewExtended filelist;
        private System.Windows.Forms.ColumnHeader colFile;
    }
}