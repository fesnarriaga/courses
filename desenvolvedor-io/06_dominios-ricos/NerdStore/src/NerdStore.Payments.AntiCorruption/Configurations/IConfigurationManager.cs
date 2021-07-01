namespace NerdStore.Payments.AntiCorruption.Configurations
{
    public interface IConfigurationManager
    {
        string GetValue(string node);
    }
}
