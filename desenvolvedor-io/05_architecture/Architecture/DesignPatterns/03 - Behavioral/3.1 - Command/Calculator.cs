using System;

namespace DesignPatterns.Command
{
    public class Calculator
    {
        private int _currentValue;

        public void Calculate(char operation, int operand)
        {
            switch (operation)
            {
                case '+': _currentValue += operand; break;
                case '-': _currentValue -= operand; break;
                case '*': _currentValue *= operand; break;
                case '/': _currentValue /= operand; break;
            }

            Console.WriteLine($"(operand {operand} | operation {operation}) => Current value = {_currentValue}");
        }
    }
}
