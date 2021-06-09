using System.Collections.Generic;

namespace DesignPatterns.AbstractFactory
{
    public class ExecuteAbstractFactory
    {
        public static void Execute()
        {
            var vehiclesToRescue = new List<Vehicle>()
            {
                VehicleCreator.Create("Celta", Size.Small),
                VehicleCreator.Create("Jetta", Size.Medium),
                VehicleCreator.Create("BMW X6", Size.Large)
            };

            vehiclesToRescue.ForEach(x => Rescue.CreateRescue(x).RescueVehicle());
        }
    }
}
