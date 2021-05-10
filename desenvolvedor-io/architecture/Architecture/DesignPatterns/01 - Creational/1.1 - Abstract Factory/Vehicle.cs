namespace DesignPatterns.AbstractFactory
{
    // Abstract Product
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public Size Size { get; set; }

        protected Vehicle(string model, Size size)
        {
            Model = model;
            Size = size;
        }
    }
}
