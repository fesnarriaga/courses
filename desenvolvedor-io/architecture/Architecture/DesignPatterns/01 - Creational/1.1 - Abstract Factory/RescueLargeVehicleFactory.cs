namespace DesignPatterns.AbstractFactory
{
    // Concrete Factory
    public class RescueLargeVehicleFactory : RescueFactory
    {
        public override TowTruck CreateTowTruck()
        {
            return TowTruckCreator.Create(Size.Large);
        }

        public override Vehicle CreateVehicle(string model, Size size)
        {
            return VehicleCreator.Create(model, size);
        }
    }
}
