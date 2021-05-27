using System;
using System.Collections.Generic;

namespace DesignPatterns.Command
{
    public class User
    {
        private readonly Calculator _calculator = new Calculator();
        private readonly List<Command> _commands = new List<Command>();
        private int _total;

        public void Commit(char operation, int operand)
        {
            var command = new CalculatorCommand(operation, operand, _calculator);
            command.Commit();

            _commands.Add(command);
            _total++;
        }

        public void Rollback(int steps)
        {
            Console.WriteLine($"\n----- Rolling back {steps} steps");

            for (var i = 0; i < steps; i++)
            {
                if (_total <= 0)
                    continue;

                var command = _commands[--_total];
                command.Rollback();
            }
        }

        public void Undo(int steps)
        {
            Console.WriteLine($"\n----- Undoing {steps} steps");

            for (var i = 0; i < steps; i++)
            {
                if (_total >= _commands.Count - 1)
                    continue;

                var command = _commands[_total++];
                command.Commit();
            }
        }
    }
}
