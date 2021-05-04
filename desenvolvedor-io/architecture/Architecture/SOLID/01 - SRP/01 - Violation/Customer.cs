using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace SOLID
{
    public class CustomerViolation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public DateTime Birth { get; set; }

        public string Add()
        {
            if (!Email.Contains("@"))
                return "Invalid e-mail";

            if (Document.Length != 11)
                return "Invalid document";

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "MyConnectionString";

                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO CUSTOMER (NAME, EMAIL, DOCUMENT, BIRTH) VALUES (@name, @email, @document, @birth);"
                };

                command.Parameters.AddWithValue("name", Name);
                command.Parameters.AddWithValue("email", Email);
                command.Parameters.AddWithValue("document", Document);
                command.Parameters.AddWithValue("birth", Birth);

                connection.Open();
                command.ExecuteNonQuery();
            }

            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            var email = new MailMessage("company@company.com", Email)
            {
                Subject = "Welcome",
                Body = "You are registered"
            };

            client.Send(email);

            return "Customer registered";
        }
    }
}
