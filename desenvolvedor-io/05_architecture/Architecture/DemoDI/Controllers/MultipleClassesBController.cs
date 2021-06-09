using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoDI.Controllers
{
    public class MultipleClassesBController : Controller
    {
        private readonly Func<string, IService> _serviceAccessor;

        public MultipleClassesBController(Func<string, IService> serviceAccessor)
        {
            _serviceAccessor = serviceAccessor;
        }

        public string Index()
        {
            return _serviceAccessor("B").Result();
        }
    }
}
