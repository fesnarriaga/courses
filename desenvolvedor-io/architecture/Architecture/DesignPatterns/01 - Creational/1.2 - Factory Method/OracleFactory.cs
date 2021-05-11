namespace DesignPatterns.FactoryMethod
{
    // Concrete Creator
    public class OracleFactory : DbFactory
    {
        public override DbConnector CreateConnector(string connectionString)
        {
            return new OracleConnector(connectionString);
        }
    }
}
