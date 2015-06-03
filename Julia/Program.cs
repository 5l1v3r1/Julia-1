using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Julia
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Root.Log("Working path is " + Root.Dir);

            if ((Root.Connection = Database.CreateConnection(Root.Dir + "julia.db")) == null)
                MessageBox.Show("SQLite database could not be connected to for an unknown reason", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Root.Log("Making sure table `tags` exists");
                Database.NonQuery("CREATE TABLE IF NOT EXISTS tags (path VARCHAR(2048), tag VARCHAR(256))", Root.Connection);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
        }
    }
}
