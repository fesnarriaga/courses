using NerdStore.Core.DomainObjects.Validations;

namespace NerdStore.Core.DomainObjects.ValueObjects
{
    public class Dimensions
    {
        public decimal Width { get; private set; }
        public decimal Height { get; private set; }
        public decimal Depth { get; private set; }

        public Dimensions(decimal width, decimal height, decimal depth)
        {
            Validation.GreaterThan(width, 0.001M, "Width must be greater than 0");
            Validation.GreaterThan(height, 0.001M, "Height must be greater than 0");
            Validation.GreaterThan(depth, 0.001M, "Depth must be greater than 0");

            Width = width;
            Height = height;
            Depth = depth;
        }

        public override string ToString()
        {
            return $"W x H x D: {Width} x {Height} x {Depth}";
        }
    }
}
