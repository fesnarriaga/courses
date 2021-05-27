namespace DesignPatterns.AbstractFactory
{
    // Concrete Product
    public class SmallVehicle : Vehicle
    {
        public SmallVehicle(string model, Size size) : base(model, size) { }
    }
}
