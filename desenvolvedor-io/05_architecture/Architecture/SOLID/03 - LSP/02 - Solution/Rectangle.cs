using System;

namespace SOLID
{
    public abstract class Parallelogram
    {
        public double Height { get; private set; }
        public double Width { get; private set; }

        public double Area => Height * Width;

        protected Parallelogram(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }

    public class Rectangle : Parallelogram
    {
        public Rectangle(int height, int width) : base(height, width) { }
    }

    public class Square : Parallelogram
    {
        public Square(int width) : base(width, width) { }

        public Square(int height, int width) : base(height, width)
        {
            if (height != width)
                throw new ArgumentException("Both sides must be equal");
        }
    }

    public class CalculateArea
    {
        private static void GetParallelogramArea(Parallelogram parallelogram)
        {
            Console.Clear();
            Console.WriteLine("Parallelogram Area\n");
            Console.WriteLine($"\n {parallelogram.Height} * {parallelogram.Width} = {parallelogram.Area} \n");
            Console.ReadKey();
        }

        public static void Calculate()
        {
            var rectangle = new Rectangle(10, 5);
            GetParallelogramArea(rectangle);

            var square = new Square(5);
            GetParallelogramArea(square);

            var square2 = new Square(10, 5);
            GetParallelogramArea(square2);
        }
    }
}
