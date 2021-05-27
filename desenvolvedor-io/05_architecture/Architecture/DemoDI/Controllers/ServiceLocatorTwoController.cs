using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoDI.Controllers
{
    public class ServiceLocatorTwoController : Controller
    {
        public void Index([FromServices] IServiceProvider serviceProvider)
        {
            // Returns null if service is not registered
            serviceProvider.GetRequiredService<ICustomerServices>().Add(new Customer());
        }
    }
}
