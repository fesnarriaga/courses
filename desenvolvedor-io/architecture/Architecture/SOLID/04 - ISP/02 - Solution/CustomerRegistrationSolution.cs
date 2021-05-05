using SOLID.Interfaces;

namespace SOLID
{
    public class CustomerRegistrationSolution : ICustomerRegistration
    {
        public void Validate()
        {
            // Do validation
        }

        public void Save()
        {
            // Save on DB
        }

        public void SendEmail()
        {
            // Send e-mail
        }
    }
}
