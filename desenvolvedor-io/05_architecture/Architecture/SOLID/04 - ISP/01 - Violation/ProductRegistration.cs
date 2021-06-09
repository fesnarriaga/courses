namespace SOLID
{
    public class ProductRegistration : IRegistration
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
            // Product do not have e-mail
            throw new System.NotImplementedException("Useless method");
        }
    }
}
