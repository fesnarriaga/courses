using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = args.Length > 0 ? args[0] : "Anonymous";

            Console.WriteLine($"Hello, {name}!");
        }
    }
}
