using System;

namespace SOLID
{
    public class CalculateAreaViolation
    {
        private static void GetRectangleArea(RectangleViolation rectangle)
        {
            Console.Clear();
            Console.WriteLine("Rectangle Area\n");
            Console.WriteLine($"\n {rectangle.Height} * {rectangle.Width} = {rectangle.Area} \n");
            Console.ReadKey();
        }

        public static void Calculate()
        {
            var square = new SquareViolation
            {
                Height = 10,
                Width = 5
            };

            GetRectangleArea(square);
        }
    }
}
