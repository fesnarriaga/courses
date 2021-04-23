using CompleteApp.Business.Interfaces.Notifications;
using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Interfaces.Services;
using CompleteApp.Business.Models;
using CompleteApp.Business.Validations;
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

        public async Task<bool> Add(Supplier supplier)
        {
            if (!Validate(new SupplierValidation(), supplier) ||
                !Validate(new AddressValidation(), supplier.Address))
                return false;

            if (_supplierRepository.Find(x => x.Document == supplier.Document).Result.Any())
            {
                Notify("Document already exists");
                return false;
            }

            await _supplierRepository.Add(supplier);
            return true;
        }

        public async Task<bool> Update(Supplier supplier)
        {
            if (!Validate(new SupplierValidation(), supplier))
                return false;

            if (_supplierRepository.Find(x => x.Document == supplier.Document && x.Id != supplier.Id).Result.Any())
            {
                Notify("Document already exists");
                return false;
            }

            await _supplierRepository.Update(supplier);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            if (_supplierRepository.GetSupplierWithAddressAndProducts(id).Result.Products.Any())
            {
                Notify("Supplier has active products");
                return false;
            }

            var address = await _addressRepository.GetAddressBySupplier(id);

            if (address != null)
                await _addressRepository.Remove(address.Id);

            await _supplierRepository.Remove(id);
            return true;
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
