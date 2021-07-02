using NerdStore.Core.Interfaces.UnitOfWork;
using NerdStore.Payments.Business.Entities;
using NerdStore.Payments.Business.Interfaces.Repositories;
using NerdStore.Payments.Data.Context;

namespace NerdStore.Payments.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentsContext _context;

        public PaymentRepository(PaymentsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Payment payment)
        {
            _context.Payments.Add(payment);
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
