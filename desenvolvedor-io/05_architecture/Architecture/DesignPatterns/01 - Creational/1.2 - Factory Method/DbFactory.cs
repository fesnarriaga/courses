using System;

namespace DesignPatterns.FactoryMethod
{
    // Abstract Creator
    public abstract class DbFactory
    {
        public static DbFactory CreateDatabase(Database database)
        {
            return database switch
            {
                Database.SqlServer => new SqlServerFactory(),
                Database.Oracle => new OracleFactory(),
                _ => throw new ApplicationException("Database not found")
            };
        }

        // Factory Method
        public abstract DbConnector CreateConnector(string connectionString);
    }
}
