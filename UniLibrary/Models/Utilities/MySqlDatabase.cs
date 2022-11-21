using System;
using MySqlConnector;

namespace UniLibrary.Models.Utilities
{

    public class SQLDatabase : IDisposable
    {
        public MySqlConnection Connection;

        public SQLDatabase(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }

    }

}