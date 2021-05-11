namespace DesignPatterns.FactoryMethod
{
    // Concrete Creator
    public class SqlServerFactory : DbFactory
    {
        public override DbConnector CreateConnector(string connectionString)
        {
            return new SqlServerConnector(connectionString);
        }
    }
}
