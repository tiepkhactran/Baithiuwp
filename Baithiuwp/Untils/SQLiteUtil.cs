using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baithiuwp.Untils
{
    class SQLiteUtil
    {
        private const string DatabaseName = "baithi.db";

        private static SQLiteUtil _instance;
        public SQLiteConnection Connection { get; }

        public static SQLiteUtil GetIntances()
        {
            if (_instance == null)
            {
                _instance = new SQLiteUtil();
            }
            return _instance;
        }

        private SQLiteUtil()
        {
            Connection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Note (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Title VARCHAR( 140 ),Content VARCHAR( 140 ), CreatedAt DateTime, UpdatedAt DateTime);";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}