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
            list.ImageListExt.Add(Properties.Resources.cd);
        }

        int GetIcon(string f)
        {
            switch (Path.GetExtension(f).TrimStart('.'))
            {
                case "iso":
                case "bin":
                case "dmg":
                case "cue":
                case "dat":
                    return 7;
                case "7z":
                case "rar":
                case "zip":
                case "bz2":
                case "gz":
                case "lz":
                case "xz":
                    return 6;
                case "sql":
                case "db":
                case "sqlite":
                case "mysql":
                    return 5;
                case "bat":
                case "exe":
                case "msi":
                case "jar":
                    return 4;
                case "png":
                case "jpg":
                case "jpeg":
                case "tiff":
                case "tif":
                case "gif":
                case "bmp":
                    return 3;
                case "rtf":
                case "doc":
                case "docx":
                case "tex":
                case "txt":
                    return 2;
                default:
                    return 1;
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

        private void menuFileTag_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter =
            "All files (*.*)|*.*|" +
            "Image (*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tiff;*.tif)|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tiff;*.tif|" +
            "Document (*.txt;*.tex;*.rtf;*.doc;*.docx;*.pdf)|*.txt;*.tex;*.rtf;*.doc;*.docx;*.pdf|" +
            "Executable (*.exe;*.bat;*.msi;*.jar)|*.exe;*.bat;*.msi;*.jar|" +
            "Archive (*.zip;*.rar;*.7z;*.bz2;*.bz;*.gz;*.lz;*.xz)|*.zip;*.rar;*.7z;*.bz2;*.bz;*.gz;*.lz;*.xz|" +
            "Disc image (*.iso;*.bin;*.dmg;*.cue;*.dat)|*.iso;*.bin;*.dmg;*.cue;*.dat|" +
            "Database (*.sql;*.db;*.sqlite;*.mysql)|*.sql;*.db;*.sqlite;*.mysql";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            TagFile tf = new TagFile();
            tf.ShowDialog();

            if (tf.Canceled) return;

            foreach (string file in ofd.FileNames)
            {
                FileAttributes attr = File.GetAttributes(file);

                ListViewItemGradient lvi = new ListViewItemGradient(Path.GetFileName(file)) { BackColor = Color.White };
                lvi.SubItems.Add(Path.GetDirectoryName(file));
                lvi.SubItems.Add("n/a");
                lvi.ImageIndexExt = ((attr & FileAttributes.Directory) == FileAttributes.Directory ? 0 : GetIcon(file));
                list.Items.Add(lvi);
            }
        }
    }
}
