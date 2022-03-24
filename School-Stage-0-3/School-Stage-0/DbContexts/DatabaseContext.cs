using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace School_Stage_0.DbContexts
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly string connectionString;
        private SQLiteConnection connection;

        public DatabaseContext()
        {
            //take the string from cfg
            connectionString = "Data Source = " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\MySQLiteDB\" + "MyDB.db" + "; version=3; new=False; datetimeformat=CurrentCulture");
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        public SQLiteConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SQLiteConnection(connectionString);

                }
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    init();
                }
                return connection;
            }
        }

        /// <summary>
        /// Dispose Connection
        /// </summary>
        public void Dispose()
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }

        private string DBDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);       //fetch App Data Local directory
        }

        private void init()
        {
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MySQLiteDB")); //creating directory name MySQLiteDB in the App Data Local directory where we will store our SQLite files
            SQLiteConnection.CreateFile(Path.Combine(DBDirectory() + @"\MySQLiteDB\MyDB.sqlite"));



            var command = connection.CreateCommand();       //create command using the SQLiteConnection      
            // you can also use this with triggers etc.
            command.CommandText = "CREATE TABLE IF NOT EXISTS Account(Id INTEGER PRIMARY KEY, Uuid varchar(64) NOT NULL, Nationality varchar(2) NOT NULL, Email VARCHAR(254) NOT NULL, Money decimal DEFAULT 0)";

            command.ExecuteNonQuery();      //execute the create command

        }



    }
}
