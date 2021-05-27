namespace DesignPatterns.AbstractFactory
{
    // Concrete Product
    public class LargeVehicle : Vehicle
    {
        public LargeVehicle(string model, Size size) : base(model, size) { }
    }
}
