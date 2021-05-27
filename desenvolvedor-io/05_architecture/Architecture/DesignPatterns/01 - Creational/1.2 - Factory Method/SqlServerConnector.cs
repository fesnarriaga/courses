using System;

namespace DesignPatterns.FactoryMethod
{
    // Concrete Product
    public class SqlServerConnector : DbConnector
    {
        public SqlServerConnector(string connectionString) : base(connectionString) { }

        public override Connection Connect()
        {
            Console.WriteLine("Connecting to SQL Server database...");

            var connection = new Connection(ConnectionString);
            connection.Open();

            return connection;
        }
    }
}
