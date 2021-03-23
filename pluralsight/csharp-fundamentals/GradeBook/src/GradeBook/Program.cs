using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            grades.Add(56.1);

            var sum = 0.0;

            foreach (var grade in grades)
            {
                sum += grade;
            }

            var average = sum / grades.Count;

            Console.WriteLine($"The average grade is {average:N1}");
        }
    }
}
