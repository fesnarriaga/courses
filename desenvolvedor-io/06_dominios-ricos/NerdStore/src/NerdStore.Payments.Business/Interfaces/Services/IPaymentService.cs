using NerdStore.Core.DomainObjects.Dtos.Payment;
using NerdStore.Payments.Business.Entities;
using System.Threading.Tasks;

namespace NerdStore.Payments.Business.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<Transaction> Pay(OrderPayment orderPayment);
    }
}
