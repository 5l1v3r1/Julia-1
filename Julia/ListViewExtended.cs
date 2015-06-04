using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Julia
{
    public enum ListViewExtendedType
    {
        Normal,
        Clean
    }

    public class ListViewExtended : ListView
    {
        public static Color cInuse = Color.FromArgb(255, 200, 140);
        public static Color cSelected = Color.FromArgb(0xC1, 0xDB, 0xFC);
        public static Color cUpdated = Color.FromArgb(140, 210, 140);

        const float MOD = 0.3f;
        const float MOD_GRADIENT = 0.5f;

        public ListViewExtendedType ExtType = ListViewExtendedType.Normal;
        public ListViewExtended()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.EnableNotifyMessage, true);

            OwnerDraw = true;
            FullRowSelect = true;
        }

        bool _SingleColumn = false;
        public bool SingleColumn
        {
            get { return _SingleColumn; }
            set
            {
                _SingleColumn = value;
                this.Scrollable = !value;
                if (value) this.Columns[0].Width = this.Width - 4;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (_SingleColumn && this.Columns.Count > 0)
                this.Columns[0].Width = this.Width - 4;
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(SystemBrushes.MenuBar, e.ClipRectangle.Left, e.ClipRectangle.Top, 50, e.ClipRectangle.Bottom);
            base.OnPaint(e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (ExtType == ListViewExtendedType.Clean)
            {
                if (this.SelectedIndices.Count > 0) foreach (ListViewItemGradient lvig in this.SelectedItems) lvig.Processed = false; //((ListViewItemGradient)this.SelectedItems[0]).Processed = false;
                foreach (ListViewItemGradient lvig in this.Items) if (lvig.Focus) { lvig.Focus = false; lvig.Processed = false; }
            }
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            if (ExtType == ListViewExtendedType.Normal) e.DrawDefault = true;
            base.OnDrawSubItem(e);
        }

        Font hFont = new Font("Microsoft Sans Serif", 7.50f, FontStyle.Regular);
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            if (ExtType == ListViewExtendedType.Normal) e.DrawDefault = true;
            else
            {
                e.DrawBackground();

                int x = e.Bounds.X + 3;
                int MID = (int)Math.Round((e.Bounds.Height / 2f) - (hFont.GetHeight() / 2f));
                int y = e.Bounds.Y + MID;

                TextRenderer.DrawText(e.Graphics, e.Header.Text, hFont, new Point(x, y), Color.Black);
            }
            base.OnDrawColumnHeader(e);
        }

        Font iFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        public List<Image> ImageListExt = new List<Image>();
        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            int MID = 0;
            if (ExtType == ListViewExtendedType.Normal) e.DrawDefault = true;
            else if (ExtType == ListViewExtendedType.Clean)
            {
                Color bg;
                if (e.Item.Selected) { bg = cSelected; ((ListViewItemGradient)e.Item).Focus = true; }
                else bg = e.Item.BackColor;
                ListViewItemGradient lvig = (ListViewItemGradient)e.Item;
                if (lvig.Processed == false)
                {
                    short r = (short)(bg.R + Math.Round((255 - bg.R) * MOD_GRADIENT));
                    short g = (short)(bg.G + Math.Round((255 - bg.G) * MOD_GRADIENT));
                    short b = (short)(bg.B + Math.Round((255 - bg.B) * MOD_GRADIENT));

                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;
                    lvig.Gradient = new LinearGradientBrush(e.Bounds.Location, new Point(0, e.Bounds.Bottom), Color.FromArgb(r, g, b), bg);
                    lvig.Processed = true;

                    if (bg == Color.White) lvig.Extreme = new Pen(Color.White);
                    else
                    {
                        r = (short)(bg.R - Math.Round(bg.R * MOD));
                        g = (short)(bg.G - Math.Round(bg.G * MOD));
                        b = (short)(bg.B - Math.Round(bg.B * MOD));
                        if (r < 0) r = 0;
                        if (g < 0) g = 0;
                        if (b < 0) b = 0;
                        lvig.Extreme = new Pen(Color.FromArgb(r, g, b));
                    }
                }

                if (!GridLines)
                {
                    /* Draw background */
                    e.Graphics.FillRectangle(lvig.Gradient, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2));
                    /* Top */
                    e.Graphics.DrawLine(lvig.Extreme, e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Y);
                    /* Bottom */
                    e.Graphics.DrawLine(lvig.Extreme, e.Bounds.X + 1, e.Bounds.Bottom - 1, e.Bounds.Width - 2, e.Bounds.Bottom - 1);
                    /* Left */
                    e.Graphics.DrawLine(lvig.Extreme, e.Bounds.X, e.Bounds.Y + 1, e.Bounds.X, e.Bounds.Bottom - 2);
                    /* Right */
                    e.Graphics.DrawLine(lvig.Extreme, e.Bounds.Right - 1, e.Bounds.Y + 1, e.Bounds.Right - 1, e.Bounds.Bottom - 2);
                }
                else
                {
                    /* Draw background */
                    e.Graphics.FillRectangle(lvig.Gradient, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2));
                    /* Top */
                    e.Graphics.DrawLine(lvig.Extreme, e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Y);
                    /* Bottom */
                    e.Graphics.DrawLine(lvig.Extreme, e.Bounds.X + 1, e.Bounds.Bottom - 2, e.Bounds.Width - 2, e.Bounds.Bottom - 2);
                    /* Left */
                    e.Graphics.DrawLine(lvig.Extreme, e.Bounds.X, e.Bounds.Y + 1, e.Bounds.X, e.Bounds.Bottom - 3);
                    /* Right */
                    e.Graphics.DrawLine(lvig.Extreme, e.Bounds.Right - 1, e.Bounds.Y + 1, e.Bounds.Right - 1, e.Bounds.Bottom - 3);
                }

                if (!SingleColumn && bg == Color.White) e.Graphics.FillRectangle(SystemBrushes.MenuBar, new Rectangle(e.Bounds.X, e.Bounds.Y, Columns[0].Width - 1, e.Bounds.Height));
                
                int offsetx = 0;
                for (int i = 0; i < Columns.Count && i < e.Item.SubItems.Count; i++)
                {
                    if (i > 0) offsetx += this.Columns[i - 1].Width;
                    int x = e.Bounds.X + 3 + offsetx;
                    if (MID == 0f) MID = (int)Math.Round((e.Bounds.Height / 2f) - (iFont.GetHeight() / 2f));
                    int y = e.Bounds.Y + MID - (GridLines ? 5 : 4);

                    if (i == 0 && ImageListExt.Count > 0 && ((ListViewItemGradient)e.Item).ImageIndexExt >= 0 && ((ListViewItemGradient)e.Item).ImageIndexExt < ImageListExt.Count)
                    {
                        e.Graphics.DrawImage(ImageListExt[((ListViewItemGradient)e.Item).ImageIndexExt], x, e.Bounds.Y + 2);
                        TextRenderer.DrawText(e.Graphics, e.Item.SubItems[i].Text, iFont, new Rectangle(x + 18, y, Columns[i].Width - 20, e.Bounds.Height), Color.Black, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                    }
                    else TextRenderer.DrawText(e.Graphics, e.Item.SubItems[i].Text, iFont, new Rectangle(x, y, Columns[i].Width, e.Bounds.Height), Color.Black, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }
            }
            base.OnDrawItem(e);
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }


        private bool isInWmPaintMsg = false;

        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int code;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0F: // WM_PAINT
                    this.isInWmPaintMsg = true;
                    base.WndProc(ref m);
                    this.isInWmPaintMsg = false;
                    break;
                case 0x204E: // WM_REFLECT_NOTIFY
                    NMHDR nmhdr = (NMHDR)m.GetLParam(typeof(NMHDR));
                    if (nmhdr.code == -12)
                    { // NM_CUSTOMDRAW
                        if (this.isInWmPaintMsg)
                            base.WndProc(ref m);
                    }
                    else
                        base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }

    public class ListViewItemGradient : ListViewItem
    {
        public Pen Extreme;
        public LinearGradientBrush Gradient;
        public bool Processed = false;
        //Color _BackgroundColor;
        public Color VirtualBackColor { get { return BackColor; } set { BackColor = value; Processed = false; } }

        public bool Focus = false;

        public int ImageIndexExt = -1;

        public ListViewItemGradient(string Name)
        {
            this.Text = Name;
        }
    }
}
