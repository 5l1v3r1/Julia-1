using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Julia
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            Root.Log("Initialized main form");

            list.ExtType = ListViewExtendedType.Clean;

            list.ImageListExt.Add(Properties.Resources.folder);
            list.ImageListExt.Add(Properties.Resources.page_white);
            list.ImageListExt.Add(Properties.Resources.page_white_text);
            list.ImageListExt.Add(Properties.Resources.image);
            list.ImageListExt.Add(Properties.Resources.application);
            list.ImageListExt.Add(Properties.Resources.database);
            list.ImageListExt.Add(Properties.Resources.page_white_zip);

            for (int i = 0; i < 7; i++)
            {
                ListViewItemGradient dong = new ListViewItemGradient("Name") { BackColor = Color.White };
                dong.SubItems.Add(@"C:\Users\Administrator.AUD122024G\Documents\Visual Studio 2012\Projects\Julia\img\");
                dong.SubItems.Add("Path");
                dong.ImageIndexExt = i;
                list.Items.Add(dong);
            }
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasitems = list.SelectedIndices.Count > 0;
            bool hasone = list.SelectedIndices.Count == 1;

            menuEditEdit.Enabled = menuEditEngrave.Enabled = hasone;
            menuEditRemove.Enabled = hasitems;
        }

        private void menuEditRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the selected " + (list.SelectedIndices.Count > 1 ? list.SelectedIndices.Count + " files" : "file") + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;
        }
    }
}
