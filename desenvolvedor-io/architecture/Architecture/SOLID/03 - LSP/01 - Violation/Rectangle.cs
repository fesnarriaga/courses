namespace SOLID
{
    public class RectangleViolation
    {
        public virtual double Height { get; set; }
        public virtual double Width { get; set; }

        public double Area => Height * Width;
    }
}
