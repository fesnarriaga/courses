namespace OOP
{
    public class CoffeeAutomation
    {
        public void PrepareCoffee()
        {
            var coffeeMachine = new CoffeeMachine();

            coffeeMachine.PowerOn();
            coffeeMachine.MakeCoffee();
            coffeeMachine.PowerOff();
        }
    }
}
