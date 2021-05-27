using System;

namespace DesignPatterns.AbstractFactory
{
    // Concrete Product
    public class SmallTowTruck : TowTruck
    {
        public SmallTowTruck(Size size) : base(size) { }

        public override void Rescue(Vehicle vehicle)
        {
            Console.WriteLine($"Helping | Size: {vehicle.Size} | Model: {vehicle.Model}");
        }
    }
}
