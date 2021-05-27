using System;

namespace DesignPatterns.Command
{
    public class ExecuteCommand
    {
        public static void Execute()
        {
            var user = new User();

            user.Commit('+', 100);
            Console.ReadKey();

            user.Commit('-', 50);
            Console.ReadKey();

            user.Commit('*', 10);
            Console.ReadKey();

            user.Commit('/', 2);
            Console.ReadKey();

            user.Rollback(4);
            Console.ReadKey();

            user.Undo(3);
        }
    }
}
