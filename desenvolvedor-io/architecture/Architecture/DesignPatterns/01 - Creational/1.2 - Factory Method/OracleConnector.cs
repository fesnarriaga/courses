using System;

namespace DesignPatterns.FactoryMethod
{
    // Concrete Product
    public class OracleConnector : DbConnector
    {
        public OracleConnector(string connectionString) : base(connectionString) { }

        public override Connection Connect()
        {
            Console.WriteLine("Connecting to Oracle database...");

            var connection = new Connection(ConnectionString);
            connection.Open();

            return connection;
        }
    }
}
