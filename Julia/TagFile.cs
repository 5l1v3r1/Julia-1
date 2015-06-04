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

        ToolStripMenuItem i2;
        public TagFile()
        {
            InitializeComponent();

            taglist.ExtType = ListViewExtendedType.Clean;
            taglist.SingleColumn = true;

            ContextMenuStrip cms = new ContextMenuStrip();

            ToolStripMenuItem i1 = new ToolStripMenuItem("Add tag...");
            i1.Image = Properties.Resources.tag_blue;
            i1.Click += delegate
            {
                AddTag at = new AddTag();
                at.ShowDialog();

                if (at.Canceled || at.Tag.Length < 1) return;

                foreach (ListViewItem i in taglist.Items)
                    if (i.Text == at.Tag) return;

                taglist.Items.Add(new ListViewItemGradient(at.Tag) { BackColor = Color.White });
            };
            cms.Items.Add(i1);

            cms.Items.Add(new ToolStripSeparator());

            i2 = new ToolStripMenuItem("Remove");
            i2.Image = Properties.Resources.cross;
            i2.Click += delegate
            {
                foreach (ListViewItem i in taglist.SelectedItems) i.Remove();
            };
            i2.Enabled = false;
            cms.Items.Add(i2);

            taglist.ContextMenuStrip = cms;
        }

        private void bTag_Click(object sender, EventArgs e)
        {
            Canceled = false;
            List<string> str = new List<string>();
            foreach (ListViewItem i in taglist.Items) str.Add(i.Text);
            Tags = str.ToArray();
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taglist_SelectedIndexChanged(object sender, EventArgs e)
        {
            i2.Enabled = taglist.SelectedIndices.Count > 0;
        }
    }
}
