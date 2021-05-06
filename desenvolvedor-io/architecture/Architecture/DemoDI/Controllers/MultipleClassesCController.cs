using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoDI.Controllers
{
    public class MultipleClassesCController : Controller
    {
        private readonly Func<string, IService> _serviceAccessor;

        public MultipleClassesCController(Func<string, IService> serviceAccessor)
        {
            _serviceAccessor = serviceAccessor;
        }

        public string Index()
        {
            return _serviceAccessor("C").Result();
        }
    }
}
