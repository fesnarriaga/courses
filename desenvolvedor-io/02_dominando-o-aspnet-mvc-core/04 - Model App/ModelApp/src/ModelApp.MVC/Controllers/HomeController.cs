using Microsoft.AspNetCore.Mvc;
using ModelApp.MVC.Data;

namespace ModelApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public HomeController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string OrderId([FromServices] IOrderRepository orderRepo)
        {
            return orderRepo.Get().Id.ToString();
        }
    }
}
