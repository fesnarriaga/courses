namespace DesignPatterns.AbstractFactory
{
    // Concrete Factory
    public class RescueSmallVehicleFactory : RescueFactory
    {
        public override TowTruck CreateTowTruck()
        {
            return TowTruckCreator.Create(Size.Small);
        }

        public override Vehicle CreateVehicle(string model, Size size)
        {
            return VehicleCreator.Create(model, size);
        }
    }
}
