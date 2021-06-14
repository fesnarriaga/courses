using Microsoft.AspNetCore.Mvc;
using System;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Guid CustomerId = Guid.Parse("4B6C735A-3FC3-4282-98A0-8676A694F6C3");
    }
}
