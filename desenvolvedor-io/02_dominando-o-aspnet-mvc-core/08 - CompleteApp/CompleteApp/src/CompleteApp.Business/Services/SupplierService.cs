using CompleteApp.Business.Interfaces.Notifications;
using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Interfaces.Services;
using CompleteApp.Business.Models;
using CompleteApp.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteApp.Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IAddressRepository _addressRepository;

        public SupplierService(
            INotificator notificator,
            ISupplierRepository supplierRepository,
            IAddressRepository addressRepository) : base(notificator)
        {
            _supplierRepository = supplierRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(Supplier supplier)
        {
            if (!Validate(new SupplierValidation(), supplier) ||
                !Validate(new AddressValidation(), supplier.Address))
                return;

            if (_supplierRepository.Find(x => x.Document == supplier.Document).Result.Any())
            {
                Notify("Supplier document already exists");
                return;
            }

            await _supplierRepository.Create(supplier);
        }

        public async Task Update(Supplier supplier)
        {
            if (!Validate(new SupplierValidation(), supplier))
                return;

            if (_supplierRepository.Find(x => x.Document == supplier.Document && x.Id == supplier.Id).Result.Any())
            {
                Notify("Supplier document already exists");
                return;
            }

            await _supplierRepository.Update(supplier);
        }

        public async Task Remove(Guid id)
        {
            if (_supplierRepository.GetSupplierWithAddressAndProducts(id).Result.Products.Any())
            {
                Notify("Supplier has linked products");
                return;
            }

            await _supplierRepository.Remove(id);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!Validate(new AddressValidation(), address))
                return;

            await _addressRepository.Update(address);
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
            _addressRepository?.Dispose();
        }
    }
}
