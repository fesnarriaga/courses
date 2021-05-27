using System.Data;
using System.Data.SqlClient;

namespace SOLID.DemoViolation
{
    public class CustomerRepository
    {
        public void AddCustomer(Customer customer)
        {
            using var cn = new SqlConnection("MyConnectionString");

            var cmd = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO CLIENTE (Name, Document, Email, CreatedAt) VALUES (@name, @document, @email, @createdAt))",
            };

            cmd.Parameters.AddWithValue("name", customer.Name);
            cmd.Parameters.AddWithValue("document", customer.Document);
            cmd.Parameters.AddWithValue("email", customer.Email);
            cmd.Parameters.AddWithValue("createdAt", customer.CreatedAt);

            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
