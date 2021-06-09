using System;

namespace DesignPatterns.Command
{
    public class CalculatorCommand : Command
    {
        private char _operation;
        private int _operand;
        private readonly Calculator _calculator;

        public char Operation { set => _operation = value; }

        public int Operand { set => _operand = value; }

        public CalculatorCommand(char operation, int operand, Calculator calculator)
        {
            _operation = operation;
            _operand = operand;
            _calculator = calculator;
        }

        public override void Commit()
        {
            _calculator.Calculate(_operation, _operand);
        }

        public override void Rollback()
        {
            _calculator.Calculate(Undo(_operation), _operand);
        }

        private static char Undo(char operation)
        {
            return operation switch
            {
                '+' => '-',
                '-' => '+',
                '*' => '/',
                '/' => '*',
                _ => throw new ArgumentException("Unknown operation")
            };
        }
    }
}
