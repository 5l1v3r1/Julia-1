using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Julia
{
    public partial class AddTag : Form
    {
        public new string Tag = "";
        public bool Canceled = true;

        public AddTag()
        {
            InitializeComponent();

            txtTag.KeyDown += (object s, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Canceled = false;
                    Tag = txtTag.Text;
                    this.Close();
                }
            };

            foreach (Main.Tag tag in Main.Tags)
                txtTag.AutoCompleteCustomSource.Add(tag.Name);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            Canceled = false;
            Tag = txtTag.Text;
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
