using System;

namespace DesignPatterns.FactoryMethod
{
    // Client
    public class ExecuteFactoryMethod
    {
        public static void Execute()
        {
            var sqlServerConnection = DbFactory
                .CreateDatabase(Database.SqlServer)
                .CreateConnector("SqlServerConnectionString")
                .Connect();

            sqlServerConnection.ExecuteCommand("SELECT * FROM sqlServerTable");
            sqlServerConnection.Close();

            Console.WriteLine("\n--------------------------------\n");

            var oracleConnection = DbFactory
                .CreateDatabase(Database.Oracle)
                .CreateConnector("OracleConnectionString")
                .Connect();

            oracleConnection.ExecuteCommand("SELECT * FROM oracleTable");
            oracleConnection.Close();
        }
    }
}
