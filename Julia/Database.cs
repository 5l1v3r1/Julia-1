using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace Julia
{
    public class Database
    {
        public static SQLiteConnection CreateConnection(string f)
        {
            if (!File.Exists(f)) SQLiteConnection.CreateFile(f);

            SQLiteConnection c = new SQLiteConnection("Data Source=" + f + ";Version=3;");
            try
            {
                c.Open();
                return c;
            }
            catch (SQLiteException)
            {
                return null;
            }
            finally
            {
                if(IsOpen(c))
                    c.Close();
            }
        }

        public static QueryResult QuickQuery(string q, SQLiteConnection c)
        {
            SQLiteDataReader r = null;
            SQLiteCommand cmd = null;
            try
            {
                List<object> cols = new List<object>();
                List<object[]> rows = new List<object[]>();

                c.Open();
                cmd = new SQLiteCommand(q, c);
                r = cmd.ExecuteReader();

                int affected = r.RecordsAffected;
                int returned = 0;
                bool readcols = false;
                while (r.Read())
                {
                    if (!readcols)
                    {
                        for (int i = 0; i < r.VisibleFieldCount; i++) cols.Add(r.GetName(i));

                        readcols = true;
                    }

                    List<Object> row = new List<object>();
                    for (int i = 0; i < r.VisibleFieldCount; i++)
                        row.Add(r.GetValue(i));
                    returned++;
                    rows.Add(row.ToArray());
                }

                r.Close();
                r.Dispose();
                r = null;

                return new QueryResult(affected, returned, cols.ToArray(), rows.ToArray());
            }
            catch (SQLiteException ex)
            {
                Root.Log("Failed to execute query '" + q + "', exception of " + ex.ErrorCode + " thrown");
                return null;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();

                if (IsOpen(c))
                    c.Close();
                if (r != null && !r.IsClosed)
                {
                    r.Close();
                    r.Dispose();
                    r = null;
                }
            }
        }

        public static QueryResult NonQuery(string q, SQLiteConnection c)
        {
            SQLiteCommand cmd = null;
            try
            {
                cmd = new SQLiteCommand(q, c);
                c.Open();
                return new QueryResult(cmd.ExecuteNonQuery(), 0, null, null);
            }
            catch (SQLiteException ex)
            {
                Root.Log("Failed to execute non-query '" + q + "', exception of " + ex.ErrorCode + " thrown");
                return null;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                if (IsOpen(c))
                    c.Close();
            }
        }

        public static bool IsOpen(SQLiteConnection c)
        {
            return (c.State == System.Data.ConnectionState.Open || c.State == System.Data.ConnectionState.Fetching || c.State == System.Data.ConnectionState.Executing);
        }
    }

    public class QueryResult
    {
        public readonly int Affected = -1;
        public readonly int Returned = -1;

        public readonly object[] Columns;
        public readonly object[][] Rows;

        public QueryResult(int a, int r, object[] c, object[][] i)
        {
            Affected = a;
            Returned = r;
            Columns = c;
            Rows = i;
        }
    }
}
