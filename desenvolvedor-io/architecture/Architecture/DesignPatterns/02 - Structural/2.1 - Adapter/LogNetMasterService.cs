using System;

namespace DesignPatterns.Adapter
{
    // Adaptee
    public class LogNetMasterService : ILogNetMaster
    {
        public void LogInfo(string message)
        {
            Console.WriteLine($"Adaptee log: {message}");
        }

        public void LogException(Exception exception)
        {
            Console.WriteLine($"Adaptee log: {exception.Message}");
        }
    }
}
