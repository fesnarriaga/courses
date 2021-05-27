using System.Data;
using System.Data.SqlClient;

namespace SOLID
{
    public class CustomerRepository
    {
        public void Add(Customer customer)
        {
            const string connectionString = "MyConnectionString";

            using var connection = new SqlConnection(connectionString);

            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO CUSTOMER (NAME, EMAIL, DOCUMENT, BIRTH) VALUES (@name, @email, @document, @birth);"
            };

            command.Parameters.AddWithValue("name", customer.Name);
            command.Parameters.AddWithValue("email", customer.Email);
            command.Parameters.AddWithValue("document", customer.Document);
            command.Parameters.AddWithValue("birth", customer.Birth);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
