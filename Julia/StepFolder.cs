using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Julia
{
    public partial class StepFolder : Form
    {
        string Path = "";
        public StepFolder(string[] s)
        {
            InitializeComponent();

            bool first = true;
            foreach (string str in s)
            {
                if (first)
                {
                    Path = System.IO.Path.GetDirectoryName(str) + Root.PathDelimiter;
                    first = false;
                }

                filelist.Items.Add(new ListViewItemGradient(System.IO.Path.GetFileName(str)) { BackColor = Color.White, ImageIndexExt = Main.GetIcon(str) });
            }

            this.Text = "Step folder - " + Path;

            filelist.ImageListExt = Main.imgList;

            filelist.ExtType = ListViewExtendedType.Clean;
            filelist.SingleColumn = true;
        }
    }
}
