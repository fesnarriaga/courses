﻿using DemoDI.Cases.RealLife;
using Microsoft.AspNetCore.Mvc;

namespace DemoDI.Controllers
{
    public class RealLifeController : Controller
    {
        private readonly ICustomerServices _customerServices;

        public RealLifeController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public void Index()
        {
            _customerServices.Add(new Customer());
        }
    }
}
