using System.Net.Mail;

namespace SOLID.DemoViolation
{
    public static class EmailService
    {
        public static void Send(string from, string to, string subject, string body)
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
                Body = body
            };

            client.Send(email);
        }
    }
}
