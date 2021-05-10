namespace DesignPatterns.AbstractFactory
{
    // Abstract Product
    public abstract class TowTruck
    {
        public Size Size { get; set; }

        protected TowTruck(Size size)
        {
            Size = size;
        }

        public abstract void Rescue(Vehicle vehicle);
    }
}
