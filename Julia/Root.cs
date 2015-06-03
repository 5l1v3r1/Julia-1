using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

public class Root
{
    //Linux uses / as a delimiter for pathes as opposed to \ which Windows uses, make sure to use the correct delimiter for the OS we've been compiled on
    #if __MonoCS__
    public const char PathDelimiter = '/';
    #else
    public const char PathDelimiter = '\\';
    #endif

    //Working directory for database files
    public static string Dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + PathDelimiter;

    //Global connection for julia.db in the working directory
    public static SQLiteConnection Connection = null;

    public static void Log(string s)
    {
        #if DEBUG
        Debug.WriteLine("# " + s);
        #endif
    }
}