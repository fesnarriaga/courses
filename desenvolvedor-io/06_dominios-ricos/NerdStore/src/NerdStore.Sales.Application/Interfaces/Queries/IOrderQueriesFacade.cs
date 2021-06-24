using NerdStore.Sales.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Sales.Application.Interfaces.Queries
{
    public interface IOrderQueriesFacade
    {
        Task<CartViewModel> GetCustomerCart(Guid customerId);
        Task<IEnumerable<OrderViewModel>> GetCustomerOrders(Guid customerId);
    }
}
