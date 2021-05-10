using System;

namespace DesignPatterns.AbstractFactory
{
    public class TowTruckCreator
    {
        public static TowTruck Create(Size size)
        {
            return size switch
            {
                Size.Small => new SmallTowTruck(size),
                Size.Medium => new MediumTowTruck(size),
                Size.Large => new LargeTowTruck(size),
                _ => throw new ApplicationException("Unknown size")
            };
        }
    }
}
