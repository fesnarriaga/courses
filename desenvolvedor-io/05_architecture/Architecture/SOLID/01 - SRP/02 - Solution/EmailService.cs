using System.Net.Mail;

namespace SOLID
{
    public static class EmailService
    {
        public static void Send(string from, string to, string subject, string message)
        {
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            var email = new MailMessage(from, to)
            {
                Subject = subject,
                Body = message
            };

            client.Send(email);
        }
    }
}
