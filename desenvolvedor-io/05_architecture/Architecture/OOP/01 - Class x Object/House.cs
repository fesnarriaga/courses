namespace OOP
{
    public class House
    {
        public int SizeM2 { get; set; }
        public int Floors { get; set; }
        public decimal Price { get; set; }
        public int GarageSlots { get; set; }
    }

    public class HouseObject
    {
        public HouseObject()
        {
            var house = new House
            {
                SizeM2 = 100,
                Floors = 2,
                Price = 100000,
                GarageSlots = 3
            };
        }
    }
}
