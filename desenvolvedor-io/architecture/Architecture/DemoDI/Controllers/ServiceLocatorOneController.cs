using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoDI.Controllers
{
    public class ServiceLocatorOneController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceLocatorOneController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Index()
        {
            // Returns null if service is not registered
            _serviceProvider.GetRequiredService<ICustomerServices>().Add(new Customer());
        }
    }
}
