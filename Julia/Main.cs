using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Julia
{
    public partial class Main : Form
    {
        ToolStripMenuItem cmsOpen;
        ToolStripMenuItem cmsOpendir;

        ToolStripMenuItem cmsEdit;
        ToolStripMenuItem cmsEngrave;
        ToolStripMenuItem cmsRemove;
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

            ContextMenuStrip cms = new ContextMenuStrip();

            cmsOpen = new ToolStripMenuItem("Open");
            cmsOpen.Enabled = false;
            Font bold = new Font(cmsOpen.Font, FontStyle.Bold);
            cmsOpen.Font = bold;
            cmsOpen.Click += delegate
            {
                OpenRunFile((ListViewItemGradient)list.SelectedItems[0]);
            };
            cms.Items.Add(cmsOpen);

            cmsOpendir = new ToolStripMenuItem("Open dir");
            cmsOpendir.Enabled = false;
            cmsOpendir.Click += delegate
            {
                OpenDirectory(list.SelectedItems[0].SubItems[1].Text + Root.PathDelimiter + list.SelectedItems[0].SubItems[0].Text);
            };
            cms.Items.Add(cmsOpendir);

            cms.Items.Add(new ToolStripSeparator());

            cmsEdit = new ToolStripMenuItem("Edit item");
            cmsEdit.Image = Properties.Resources.pencil;
            cmsEdit.Click += menuEditEdit_Click;
            cmsEdit.Enabled = false;
            cms.Items.Add(cmsEdit);

            cmsEngrave = new ToolStripMenuItem("Engrave...");
            cmsEngrave.Image = Properties.Resources.page_white_edit;
            cmsEngrave.Click += menuEditEngrave_Click;
            cmsEngrave.Enabled = false;
            cms.Items.Add(cmsEngrave);

            cms.Items.Add(new ToolStripSeparator());

            cmsRemove = new ToolStripMenuItem("Remove");
            cmsRemove.Image = Properties.Resources.cross;
            cmsRemove.Click += menuEditRemove_Click;
            cmsRemove.Enabled = false;
            cms.Items.Add(cmsRemove);

            list.ContextMenuStrip = cms;

            list.DoubleClick += delegate
            {
                OpenRunFile((ListViewItemGradient)list.SelectedItems[0]);
            };

            ReloadTags();
            ReloadFiles();
        }

        void OpenRunFile(ListViewItemGradient i)
        {
            string s = i.SubItems[1].Text + Root.PathDelimiter + i.SubItems[0].Text;
            bool exe = i.ImageIndexExt == 4;
            if (!File.Exists(s)) return;

            if (exe && MessageBox.Show("Are you sure you want to execute this file?\n\nExecutables can damage your computer, make sure to only run files from sources you trust.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;

            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = s;
                if (exe)
                {
                    proc.Exited += delegate { i.VirtualBackColor = Color.White; };
                    i.VirtualBackColor = ListViewExtended.cInuse;
                }
                proc.EnableRaisingEvents = true;
                proc.Start();
                list.SelectedItems.Clear();
            }
            catch (Win32Exception)
            {
                proc.Dispose();
                MessageBox.Show("There is no default program setup to open this type of file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OpenDirectory(string d) {
            if (!File.Exists(d)) return;

            Process.Start("explorer.exe", "/select,\"" + d + "\"");
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

            menuEditEdit.Enabled = menuEditEngrave.Enabled = cmsEdit.Enabled = cmsEngrave.Enabled = cmsOpen.Enabled = cmsOpendir.Enabled = hasone;
            menuEditRemove.Enabled = cmsRemove.Enabled = hasitems;

            if (hasone)
            {
                ListViewItemGradient i = (ListViewItemGradient)list.SelectedItems[0];

                if (i.ImageIndexExt == 4)
                {
                    cmsOpen.Text = "Execute";
                    cmsOpen.Image = Properties.Resources.application_xp_terminal;
                }
                else
                {
                    cmsOpen.Text = "Open";
                    cmsOpen.Image = null;
                }
            }
        }

        private void menuEditRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the selected " + (list.SelectedIndices.Count > 1 ? list.SelectedIndices.Count + " files" : "file") + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach (ListViewItem i in list.SelectedItems)
            {
                if (Database.NonQuery("DELETE FROM files WHERE rowid=" + i.SubItems[3].Text, Root.Connection) != null)
                {
                    i.Remove();
                    lastrowid--;
                }
            }
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

            bool newtag = false;

            foreach (string tag in tf.Tags)
            {
                Root.Log("Making sure tag `" + tag + "` exists");
                string rtag = tag.Replace("'", "''");
                QueryResult res = Database.NonQuery("INSERT INTO tags (name) SELECT '" + rtag + "' WHERE NOT EXISTS(SELECT 1 FROM tags WHERE name='" + rtag + "');", Root.Connection);
                if (res.Affected > 0) newtag = true;
            }
            if(newtag) ReloadTags();

            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (string tag in tf.Tags)
            foreach (Tag t in Tags)
                if (t.Name == tag)
                {
                    sb.Append((first ? "" : ",") + t.ID);
                    first = false;
                }

            bool newfile = false;
            foreach (string file in ofd.FileNames)
            {
                string rfile = file.Replace("'", "''");
                if (Database.QuickQuery("SELECT 1 FROM files WHERE path='" + rfile + "'", Root.Connection).Returned > 0) continue;

                newfile = true;
                QueryResult res = Database.NonQuery("INSERT INTO files (path,tags) VALUES ('" + rfile + "', '" + sb.ToString() + "')", Root.Connection);
            }
            if (newfile) ReloadFiles();
        }

        public new class Tag
        {
            public long ID;
            public string Name;

            public Tag(long i, string n)
            {
                ID = i;
                Name = n;
            }
        }

        long lasttagid = -1;
        public static List<Tag> Tags = new List<Tag>();
        void ReloadTags()
        {
            QueryResult res = Database.QuickQuery("SELECT rowid,* FROM tags where rowid>" + lasttagid, Root.Connection);

            foreach (object[] obj in res.Rows)
            {
                lasttagid = (long)obj[0];
                Tags.Add(new Tag((long)obj[0], (string)obj[1]));
            }
            Root.Log("Loaded " + res.Returned + " new tags");
        }

        long lastrowid = -1;
        void ReloadFiles()
        {
            QueryResult res = Database.QuickQuery("SELECT rowid,* FROM files where rowid>" + lastrowid, Root.Connection);

            foreach (object[] obj in res.Rows)
            {
                lastrowid = (long)obj[0];

                string file = (string)obj[1];
                string[] tags = ((string)obj[2]).Split(',');

                StringBuilder sb = new StringBuilder();
                bool first = true;
                foreach (string tag in tags)
                {
                    foreach (Tag t in Tags)
                        if (t.ID.ToString() == tag)
                        {
                            sb.Append((first ? "" : ", ") + t.Name);
                            first = false;
                        }
                }

                FileAttributes attr = File.GetAttributes(file);

                ListViewItemGradient lvi = new ListViewItemGradient(Path.GetFileName(file)) { BackColor = Color.White };
                lvi.SubItems.Add(Path.GetDirectoryName(file));
                lvi.SubItems.Add(sb.ToString());
                lvi.SubItems.Add(((long)obj[0]).ToString());
                lvi.ImageIndexExt = ((attr & FileAttributes.Directory) == FileAttributes.Directory ? 0 : GetIcon(file));
                list.Items.Add(lvi);
            }
            Root.Log("Loaded " + res.Returned + " new files");
        }

        private void menuEditEdit_Click(object sender, EventArgs e)
        {

        }

        private void menuEditEngrave_Click(object sender, EventArgs e)
        {

        }
    }
}
