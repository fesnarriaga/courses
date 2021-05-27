using System;

namespace DesignPatterns.Adapter
{
    // Target
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Target log: {message}");
        }

        public void LogError(Exception exception)
        {
            Console.WriteLine($"Target log: {exception.Message}");
        }
    }
}
