using DesignPatterns.AbstractFactory;
using DesignPatterns.FactoryMethod;
using DesignPatterns.Singleton;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("------------------------");
            Console.WriteLine("Creational Patterns");
            Console.WriteLine("------------------------");
            Console.WriteLine("1 - Abstract Factory");
            Console.WriteLine("2 - Method Factory");
            Console.WriteLine("3 - Singleton");
            Console.WriteLine("------------------------");
            Console.WriteLine("Structural Patterns");
            Console.WriteLine("------------------------");
            Console.WriteLine("4 - Adapter");
            Console.WriteLine("5 - Facade");
            Console.WriteLine("6 - Composite");
            Console.WriteLine("------------------------");
            Console.WriteLine("Behavioral Patterns");
            Console.WriteLine("------------------------");
            Console.WriteLine("7 - Command");
            Console.WriteLine("8 - Strategy");
            Console.WriteLine("9 - Observer");
            Console.WriteLine("------------------------");

            var option = Console.ReadKey();

            Console.WriteLine("");
            Console.WriteLine("------------------------");
            Console.WriteLine("");

            switch (option.KeyChar)
            {
                case '1':
                    ExecuteAbstractFactory.Execute();
                    break;
                case '2':
                    ExecuteFactoryMethod.Execute();
                    break;
                case '3':
                    ExecuteSingleton.Execute();
                    break;
                case '4':
                    ExecuteAbstractFactory.Execute();
                    break;
                case '5':
                    ExecuteAbstractFactory.Execute();
                    break;
                case '6':
                    ExecuteAbstractFactory.Execute();
                    break;
                case '7':
                    ExecuteAbstractFactory.Execute();
                    break;
                case '8':
                    ExecuteAbstractFactory.Execute();
                    break;
                case '9':
                    ExecuteAbstractFactory.Execute();
                    break;
            }

            Console.ReadKey();
            Console.Clear();
            Main();
        }
    }
}
