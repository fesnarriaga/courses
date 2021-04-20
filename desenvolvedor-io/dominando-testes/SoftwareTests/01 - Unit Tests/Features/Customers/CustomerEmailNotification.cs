using MediatR;

namespace Features.Customers
{
    public class CustomerEmailNotification : INotification
    {
        public string Sender { get; private set; }
        public string Recipient { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }

        public CustomerEmailNotification(string sender, string recipient, string subject, string message)
        {
            Sender = sender;
            Recipient = recipient;
            Subject = subject;
            Message = message;
        }
    }
}
