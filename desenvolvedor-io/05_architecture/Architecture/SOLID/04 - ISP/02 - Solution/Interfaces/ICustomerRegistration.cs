namespace SOLID.Interfaces
{
    public interface ICustomerRegistration : IRegistration
    {
        void Validate();
        void SendEmail();
    }
}
