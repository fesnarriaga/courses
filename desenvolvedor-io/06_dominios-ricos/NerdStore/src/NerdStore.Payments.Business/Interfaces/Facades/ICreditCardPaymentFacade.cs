using NerdStore.Payments.Business.Entities;
using NerdStore.Payments.Business.ViewModels;

namespace NerdStore.Payments.Business.Interfaces.Facades
{
    public interface ICreditCardPaymentFacade
    {
        Transaction Pay(Order order, Payment payment);
    }
}
