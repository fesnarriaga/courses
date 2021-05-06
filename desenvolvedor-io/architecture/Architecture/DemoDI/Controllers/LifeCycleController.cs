using Microsoft.AspNetCore.Mvc;
using System;
using DemoDI.Cases;

namespace DemoDI.Controllers
{
    public class LifeCycleController : Controller
    {
        public OperationService OperationServiceOne { get; }
        public OperationService OperationServiceTwo { get; }

        public LifeCycleController(OperationService operationServiceOne, OperationService operationServiceTwo)
        {
            OperationServiceOne = operationServiceOne;
            OperationServiceTwo = operationServiceTwo;
        }

        public string Index()
        {
            return
                "First instance: " + Environment.NewLine +
                OperationServiceOne.Transient.OperationId + Environment.NewLine +
                OperationServiceOne.Scoped.OperationId + Environment.NewLine +
                OperationServiceOne.Singleton.OperationId + Environment.NewLine +
                OperationServiceOne.SingletonInstance.OperationId + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Second instance: " + Environment.NewLine +
                OperationServiceTwo.Transient.OperationId + Environment.NewLine +
                OperationServiceTwo.Scoped.OperationId + Environment.NewLine +
                OperationServiceTwo.Singleton.OperationId + Environment.NewLine +
                OperationServiceTwo.SingletonInstance.OperationId + Environment.NewLine;
        }
    }
}
