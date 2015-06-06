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
            taglist.ExtType = ListViewExtendedType.Clean;
            taglist.SingleColumn = true;

            img.Cursor = Cursors.Hand;
            bool Dragging = false;
            img.MouseDown += (object sender, MouseEventArgs e) =>
            {
                Dragging = true;
                if (!toggle && img.Image.Size.Height > img.Size.Height && img.Image.Size.Width > img.Size.Width)
                {
                    double xratio = (double)img.Image.Size.Width / (double)img.Size.Width;
                    double yratio = (double)img.Image.Size.Height / (double)img.Size.Height;

                    int xoffset = (int)Math.Round((e.X * xratio) - (img.Image.Size.Width / 2d));
                    int yoffset = (int)Math.Round((e.Y * yratio) - (img.Image.Size.Height / 2d));

                    int roffset = (xoffset > 0 ? xoffset : 0);
                    int boffset = (yoffset > 0 ? yoffset : 0);
                    int loffset = (xoffset < 0 ? -xoffset : 0);
                    int toffset = (yoffset < 0 ? -yoffset : 0);

                    img.Padding = new Padding(loffset, toffset, roffset, boffset);
                }
                else
                    img.Padding = new Padding(0, 0, 0, 0);
                img.SizeMode = (toggle ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage);
                toggle = !toggle;
            };
            img.MouseUp += delegate { Dragging = false; };
            img.MouseMove += (object sender, MouseEventArgs e) =>
            {
                if (Dragging)
                {
                    double xratio = (double)img.Image.Size.Width / (double)img.Size.Width;
                    double yratio = (double)img.Image.Size.Height / (double)img.Size.Height;

                    int xoffset = (int)Math.Round((e.X * xratio) - (img.Image.Size.Width / 2d));
                    int yoffset = (int)Math.Round((e.Y * yratio) - (img.Image.Size.Height / 2d));

                    int roffset = (xoffset > 0 ? xoffset : 0);
                    int boffset = (yoffset > 0 ? yoffset : 0);
                    int loffset = (xoffset < 0 ? -xoffset : 0);
                    int toffset = (yoffset < 0 ? -yoffset : 0);

                    img.Padding = new Padding(loffset, toffset, roffset, boffset);
                    img.Invalidate();
                }
            };
        }
        bool toggle = false;

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

            if (img.Image != null) img.Image.Dispose();
            switch (((ListViewItemGradient)filelist.SelectedItems[0]).ImageIndexExt)
            {
                case Root.ICON_IMG:
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                    toggle = false;

                    if(size <= Root.MAX_FILE_SIZE_IMG)
                        img.Image = Image.FromFile(rpath);
                    break;
            }
        }
    }
}
