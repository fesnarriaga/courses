using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoDI.Controllers
{
    public class MultipleClassesAController : Controller
    {
        private readonly Func<string, IService> _serviceAccessor;

        public MultipleClassesAController(Func<string, IService> serviceAccessor)
        {
            _serviceAccessor = serviceAccessor;
        }

        public string Index()
        {
            return _serviceAccessor("A").Result();
        }
    }
}
