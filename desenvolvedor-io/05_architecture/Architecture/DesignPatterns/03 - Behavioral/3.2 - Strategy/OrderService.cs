using DesignPatterns.Facade;

namespace DesignPatterns.Strategy
{
    public class OrderService
    {
        private readonly IPaymentService _paymentService;

        public OrderService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public Payment ExecutePayment(Order order, Payment payment)
        {
            return _paymentService.ExecutePayment(order, payment);
        }
    }
}
