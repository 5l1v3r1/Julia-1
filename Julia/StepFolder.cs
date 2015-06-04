using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            img.Cursor = Cursors.Hand;
            bool toggle = false;
            img.Click += delegate
            {
                img.SizeMode = (toggle ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage);
                toggle = !toggle;
            };
            //img.MouseEnter += delegate { img.Cursor = Cursors.Hand; };
            //img.MouseLeave += delegate { img.Cursor = Cursors.SizeAll; };
        }

        private void filelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filelist.SelectedIndices.Count < 1) return;

            string rpath = Path + filelist.SelectedItems[0].Text;
            if (!File.Exists(rpath))
            {
                filelist.SelectedItems[0].Remove();
                return;
            }

            long size = (new FileInfo(rpath)).Length;

            switch (((ListViewItemGradient)filelist.SelectedItems[0]).ImageIndexExt)
            {
                case Root.ICON_IMG:
                    if(img.Image != null) img.Image.Dispose();
                    if(size <= Root.MAX_FILE_SIZE_IMG)
                        img.Image = Image.FromFile(rpath);
                    break;
            }
        }
    }
}
