namespace DesignPatterns.AbstractFactory
{
    // Concrete Factory
    public class RescueMediumVehicleFactory : RescueFactory
    {
        public override TowTruck CreateTowTruck()
        {
            return TowTruckCreator.Create(Size.Medium);
        }

        public override Vehicle CreateVehicle(string model, Size size)
        {
            return VehicleCreator.Create(model, size);
        }
    }
}
