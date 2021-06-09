using System;

namespace DesignPatterns.AbstractFactory
{
    // Concrete Product
    public class LargeTowTruck : TowTruck
    {
        public LargeTowTruck(Size size) : base(size) { }

        public override void Rescue(Vehicle vehicle)
        {
            Console.WriteLine($"Helping | Size: {vehicle.Size} | Model: {vehicle.Model}");
        }
    }
}
