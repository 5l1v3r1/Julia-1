using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

public class Root
{
    //Linux uses / as a delimiter for paths as opposed to \ which Windows uses, make sure to use the correct delimiter for the OS we've been compiled on
    #if __MonoCS__
    public const char PathDelimiter = '/';
    #else
    public const char PathDelimiter = '\\';
    #endif

    //Working directory for database files
    public static string Dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + PathDelimiter;

    //Global connection for julia.db in the working directory
    public static SQLiteConnection Connection = null;

    //Constants for icon nums
    public const int
    ICON_FOLDER = 0,
    ICON_FILE = 1,
    ICON_TXT = 2,
    ICON_IMG = 3,
    ICON_EXE = 4,
    ICON_DB = 5,
    ICON_ARCHIVE = 6,
    ICON_DISC = 7
    ;

    public static void Log(string s)
    {
        #if DEBUG
        Debug.WriteLine("# " + s);
        #endif
    }
}