namespace OOP
{
    public class CoffeeMachine : Appliance
    {
        public CoffeeMachine() : base("Default", 220) { }

        public CoffeeMachine(string name, int voltage) : base(name, voltage) { }

        public void MakeCoffee()
        {
            Test();
            WarmWater();
            GrindBean();
        }

        public override void PowerOn()
        {
            // Check water level
        }

        public override void PowerOff()
        {
            // heater cooling
        }

        public override void Test()
        {
            // Specialized tests for coffee machine
        }

        private static void WarmWater() { }

        private static void GrindBean() { }
    }
}
