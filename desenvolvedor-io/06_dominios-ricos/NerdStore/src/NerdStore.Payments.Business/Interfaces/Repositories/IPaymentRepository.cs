using NerdStore.Core.Interfaces.Repositories;
using NerdStore.Payments.Business.Entities;

namespace NerdStore.Payments.Business.Interfaces.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        void Add(Payment payment);

        void AddTransaction(Transaction transaction);
    }
}
