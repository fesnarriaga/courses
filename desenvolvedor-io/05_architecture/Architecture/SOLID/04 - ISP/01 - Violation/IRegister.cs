namespace SOLID
{
    public interface IRegistration
    {
        void Validate();
        void Save();
        void SendEmail();
    }
}
