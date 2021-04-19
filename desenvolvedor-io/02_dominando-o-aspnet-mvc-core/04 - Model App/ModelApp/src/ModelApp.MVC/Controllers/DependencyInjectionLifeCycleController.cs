using Microsoft.AspNetCore.Mvc;
using ModelApp.MVC.Services;
using System;

namespace ModelApp.MVC.Controllers
{
    public class DependencyInjectionLifeCycleController : Controller
    {
        public OperationService OperationServiceFirstInstance { get; }
        public OperationService OperationServiceSecondInstance { get; }

        public DependencyInjectionLifeCycleController(
            OperationService operationServiceFirstInstance,
            OperationService operationServiceSecondInstance)
        {
            OperationServiceFirstInstance = operationServiceFirstInstance;
            OperationServiceSecondInstance = operationServiceSecondInstance;
        }

        [Route("di")]
        public string Index()
        {
            return
                "First Instance: " + Environment.NewLine +
                OperationServiceFirstInstance.Transient.Id + Environment.NewLine +
                OperationServiceFirstInstance.Scoped.Id + Environment.NewLine +
                OperationServiceFirstInstance.Singleton.Id + Environment.NewLine +
                OperationServiceFirstInstance.SingletonInstance.Id + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Second Instance: " + Environment.NewLine +
                OperationServiceSecondInstance.Transient.Id + Environment.NewLine +
                OperationServiceSecondInstance.Scoped.Id + Environment.NewLine +
                OperationServiceSecondInstance.Singleton.Id + Environment.NewLine +
                OperationServiceSecondInstance.SingletonInstance.Id + Environment.NewLine;
        }
    }
}
