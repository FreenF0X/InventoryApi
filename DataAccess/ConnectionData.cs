namespace DataAccess
{
    public class ConnectionData
    {
        private readonly string connectionString;
        public ConnectionData(string connString)
        {
            connectionString = connString;
        }

        public string GetConnectionString()
        { 
            return connectionString; 
        }
    }
}
