using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Julia
{
    public partial class TagFile : Form
    {
        public string[] Tags;
        public bool Canceled = true;

        public TagFile()
        {
            InitializeComponent();

            taglist.ExtType = ListViewExtendedType.Clean;
            taglist.SingleColumn = true;

            ContextMenuStrip cms = new ContextMenuStrip();

            ToolStripMenuItem i1 = new ToolStripMenuItem("Add tag...");
            i1.Image = Properties.Resources.tag_blue;
            cms.Items.Add(i1);

            cms.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem i2 = new ToolStripMenuItem("Remove");
            i2.Image = Properties.Resources.cross;
            i2.Enabled = false;
            cms.Items.Add(i2);

            taglist.ContextMenuStrip = cms;
        }

        private void bTag_Click(object sender, EventArgs e)
        {
            Canceled = false;
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
