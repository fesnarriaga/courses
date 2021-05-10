namespace DesignPatterns.AbstractFactory
{
    // Abstract Factory
    public abstract class RescueFactory
    {
        public abstract TowTruck CreateTowTruck();
        public abstract Vehicle CreateVehicle(string model, Size size);
    }
}
