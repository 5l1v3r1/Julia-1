using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Julia
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Root.Log("Working path is " + Root.Dir);

            if ((Root.Connection = Database.CreateConnection(Root.Dir + "julia.db")) == null)
                MessageBox.Show("SQLite database could not be connected to for an unknown reason", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Root.Log("Making sure tables `tags` and `files` exist");
                Database.NonQuery("CREATE TABLE IF NOT EXISTS tags (name VARCHAR(256))", Root.Connection);
                Database.NonQuery("CREATE TABLE IF NOT EXISTS files (path VARCHAR(2048), tags VARCHAR(2048))", Root.Connection); //The maximum amount of tags allowed for a file will be more or less a third of the size of the tags column.

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
        }
    }
}
