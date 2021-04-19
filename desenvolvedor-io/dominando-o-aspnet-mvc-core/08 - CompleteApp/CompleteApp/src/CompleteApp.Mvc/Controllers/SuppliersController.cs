using AutoMapper;
using CompleteApp.Business.Interfaces.Notifications;
using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Interfaces.Services;
using CompleteApp.Business.Models;
using CompleteApp.Mvc.Extensions.Identity;
using CompleteApp.Mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompleteApp.Mvc.Controllers
{
    [Authorize]
    public class SuppliersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierService _supplierService;

        public SuppliersController(
            INotificator notificator,
            IMapper mapper,
            ISupplierRepository supplierRepository,
            ISupplierService supplierService) : base(notificator)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _supplierService = supplierService;
        }

        [AllowAnonymous]
        [Route("suppliers-list")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll()));
        }

        [AllowAnonymous]
        [Route("supplier-details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [ClaimsAuthorize("Supplier", "Create")]
        [Route("create-supplier")]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Supplier", "Create")]
        [Route("create-supplier")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
                return View(supplierViewModel);

            await _supplierService.Add(_mapper.Map<Supplier>(supplierViewModel));

            if (!ValidOperation())
                return View(supplierViewModel);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Supplier", "Update")]
        [Route("edit-supplier/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddressAndProducts(id);

            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [ClaimsAuthorize("Supplier", "Update")]
        [Route("edit-supplier/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(supplierViewModel);

            await _supplierService.Update(_mapper.Map<Supplier>(supplierViewModel));

            if (!ValidOperation())
                return View(await GetSupplierWithAddressAndProducts(id));

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Supplier", "Delete")]
        [Route("delete-supplier/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        [ClaimsAuthorize("Supplier", "Delete")]
        [Route("delete-supplier/{id:guid}")]
        [HttpPost]
        [ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            await _supplierService.Remove(id);

            if (!ValidOperation())
                return View(supplierViewModel);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [Route("get-supplier-address/{supplierId:guid}")]
        public async Task<IActionResult> GetAddress(Guid supplierId)
        {
            var supplier = await GetSupplierWithAddress(supplierId);

            if (supplier == null)
                return NotFound();

            return PartialView("_AddressDetails", supplier);
        }

        [ClaimsAuthorize("Supplier", "Update")]
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

        [ClaimsAuthorize("Supplier", "Update")]
        [Route("update-supplier-address/{supplierId:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(SupplierViewModel supplierViewModel)
        {
            ModelState.Remove(nameof(supplierViewModel.Name));
            ModelState.Remove(nameof(supplierViewModel.Document));

            if (!ModelState.IsValid)
                return PartialView("_AddressUpdate", supplierViewModel);

            await _supplierService.UpdateAddress(_mapper.Map<Address>(supplierViewModel.Address));

            if (!ValidOperation())
                return PartialView("_AddressUpdate", supplierViewModel);

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
