namespace DesignPatterns.Facade
{
    public interface ICreditCardPaymentFacade
    {
        bool ExecutePayment(Order order, Payment payment);
    }
}
