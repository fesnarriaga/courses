using CompleteApp.Business.Interfaces.Services;
using CompleteApp.Business.Models;
using CompleteApp.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        public async Task Add(Supplier supplier)
        {
            if (!Validate(new SupplierValidation(), supplier) &&
                !Validate(new AddressValidation(), supplier.Address))
                return;

            return;
        }

        public async Task Update(Supplier supplier)
        {
            if (!Validate(new SupplierValidation(), supplier))
                return;
        }

        public async Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAddress(Address address)
        {
            if (!Validate(new AddressValidation(), address))
                return;
        }
    }
}
