using AutoMapper;
using CompleteApp.Business.Interfaces;
using CompleteApp.Business.Models;
using CompleteApp.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompleteApp.Business.Interfaces.Repositories;

namespace CompleteApp.Mvc.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IAddressRepository _addressRepository;

        public SuppliersController(
            IMapper mapper,
            ISupplierRepository supplierRepository,
            IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _addressRepository = addressRepository;
        }

        [Route("suppliers-list")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll()));
        }

        [Route("supplier-details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [Route("create-supplier")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("create-supplier")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
                return View(supplierViewModel);

            await _supplierRepository.Create(_mapper.Map<Supplier>(supplierViewModel));

            return RedirectToAction(nameof(Index));
        }

        [Route("edit-supplier/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddressAndProducts(id);

            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [Route("edit-supplier/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(supplierViewModel);

            await _supplierRepository.Update(_mapper.Map<Supplier>(supplierViewModel));

            return RedirectToAction(nameof(Index));
        }

        [Route("delete-supplier/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [Route("delete-supplier/{id:guid}")]
        [HttpPost]
        [ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            await _supplierRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        [Route("get-supplier-address/{supplierId:guid}")]
        public async Task<IActionResult> GetAddress(Guid supplierId)
        {
            var supplier = await GetSupplierWithAddress(supplierId);

            if (supplier == null)
                return NotFound();

            return PartialView("_AddressDetails", supplier);
        }

        [Route("update-supplier-address/{supplierId:guid}")]
        public async Task<IActionResult> UpdateAddress(Guid supplierId)
        {
            var supplier = await GetSupplierWithAddress(supplierId);

            if (supplier == null)
            {
                return NotFound();
            }

            return PartialView("_AddressUpdate", new SupplierViewModel { Address = supplier.Address });
        }

        [Route("update-supplier-address/{supplierId:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(SupplierViewModel supplierViewModel)
        {
            ModelState.Remove(nameof(supplierViewModel.Name));
            ModelState.Remove(nameof(supplierViewModel.Document));

            if (!ModelState.IsValid)
                return PartialView("_AddressUpdate", supplierViewModel);

            await _addressRepository.Update(_mapper.Map<Address>(supplierViewModel.Address));

            var url = Url.Action("GetAddress", "Suppliers", new { supplierId = supplierViewModel.Address.SupplierId });

            return Json(new { success = true, url });
        }

        private async Task<SupplierViewModel> GetSupplierWithAddress(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierWithAddress(id));
        }

        private async Task<SupplierViewModel> GetSupplierWithAddressAndProducts(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierWithAddressAndProducts(id));
        }
    }
}
