using MySql.Data.MySqlClient;

namespace UAS_SIMANIS
{
    internal class DB
    {
        private MySqlConnection connection =
            new MySqlConnection("server=localhost;uid=root;pwd=;database=simanis");

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}
