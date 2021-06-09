namespace DesignPatterns.Facade
{
    public interface IPaymentService
    {
        Payment ExecutePayment(Order order, Payment payment);
    }
}
