using System;

namespace DesignPatterns.AbstractFactory
{
    public class Rescue
    {
        private readonly Vehicle _vehicle;
        private readonly TowTruck _towTruck;

        public Rescue(RescueFactory rescueFactory, Vehicle vehicle)
        {
            _vehicle = rescueFactory.CreateVehicle(vehicle.Model, vehicle.Size);
            _towTruck = rescueFactory.CreateTowTruck();
        }

        public void RescueVehicle()
        {
            _towTruck.Rescue(_vehicle);
        }

        public static Rescue CreateRescue(Vehicle vehicle)
        {
            return vehicle.Size switch
            {
                Size.Small => new Rescue(new RescueSmallVehicleFactory(), vehicle),
                Size.Medium => new Rescue(new RescueMediumVehicleFactory(), vehicle),
                Size.Large => new Rescue(new RescueLargeVehicleFactory(), vehicle),
                _ => throw new ApplicationException("Invalid vehicle")
            };
        }
    }
}
