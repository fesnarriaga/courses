using AutoMapper;
using CompleteApp.Business.Interfaces;
using CompleteApp.Business.Models;
using CompleteApp.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompleteApp.Mvc.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public SuppliersController(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
                return View(supplierViewModel);

            await _supplierRepository.Create(_mapper.Map<Supplier>(supplierViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddressAndProducts(id);

            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

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

        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            return View(supplierViewModel);
        }

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
