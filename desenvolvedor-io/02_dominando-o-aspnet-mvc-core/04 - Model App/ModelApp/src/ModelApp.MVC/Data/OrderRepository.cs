using ModelApp.MVC.Models;

namespace ModelApp.MVC.Data
{
    public class OrderRepository : IOrderRepository
    {
        public Order Get()
        {
            return new Order();
        }
    }

    public interface IOrderRepository
    {
        Order Get();
    }
}
