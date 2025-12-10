using MySql.Data.MySqlClient;

public class DB
{
    private MySqlConnection connection;

    public DB()
    {
        connection = new MySqlConnection("server=localhost;uid=root;pwd=;database=db_simanis");
    }

    public MySqlConnection GetConnection()
    {
        return connection;
    }

    public void Open()
    {
        if (connection.State == System.Data.ConnectionState.Closed)
            connection.Open();
    }

    public void Close()
    {
        if (connection.State == System.Data.ConnectionState.Open)
            connection.Close();
    }
}
