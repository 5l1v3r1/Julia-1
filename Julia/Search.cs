using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Julia
{
    public partial class Search : Form
    {
        public bool Canceled = true;
        public Search()
        {
            InitializeComponent();

            tabs.Selecting += delegate
            {
                this.Height = (tabs.SelectedIndex == 1 ? 400 : 137);
            };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Canceled = false;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Multiple search terms can be used by separating them with commas.\nPrepending a search term with an exclamation mark (!) will exclude that tag from your search.\nPrepending or appending a search term with an asterisk (*) will search for anything beginning or ending respectively with that term.\n\nExample: 'Work, !Homework, *work' will match files only with the tag 'Work', but not the tag 'Homework', but must also contain a tag that ends in 'work' such as 'Artwork' or 'Important work'.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
