namespace SOLID
{
    public class SquareViolation : RectangleViolation
    {
        public override double Height
        {
            set => base.Height = base.Width = value;
        }

        public override double Width
        {
            set => base.Height = base.Width = value;
        }
    }
}
