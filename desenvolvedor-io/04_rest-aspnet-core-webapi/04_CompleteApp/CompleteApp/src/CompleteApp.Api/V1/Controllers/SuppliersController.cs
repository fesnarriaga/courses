﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CompleteApp.Api.Controllers;
using CompleteApp.Api.Extensions.Auth;
using CompleteApp.Api.ViewModels;
using CompleteApp.Business.Interfaces.Auth;
using CompleteApp.Business.Interfaces.Notifications;
using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Interfaces.Services;
using CompleteApp.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompleteApp.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    //[ApiVersion("1.0",Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SuppliersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IAddressRepository _addressRepository;

        public SuppliersController(
            IMapper mapper,
            ISupplierService supplierService,
            ISupplierRepository supplierRepository,
            IAddressRepository addressRepository,
            INotificator notificator,
            IUser user) : base(notificator, user)
        {
            _mapper = mapper;
            _supplierService = supplierService;
            _supplierRepository = supplierRepository;
            _addressRepository = addressRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<SupplierViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());
        }

        [ClaimsAuthorize("Supplier", "Read")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> GetById(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddressAndProducts(id);

            if (supplierViewModel == null)
                return NotFound();

            return supplierViewModel;
        }

        [ClaimsAuthorize("Supplier", "Create")]
        [HttpPost]
        public async Task<ActionResult<SupplierViewModel>> Add(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _supplierService.Add(_mapper.Map<Supplier>(supplierViewModel));

            return CustomResponse(supplierViewModel);
        }

        [ClaimsAuthorize("Supplier", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Update(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
            {
                NotifyError("Invalid resource");
                return CustomResponse(supplierViewModel);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _supplierService.Update(_mapper.Map<Supplier>(supplierViewModel));

            return CustomResponse(supplierViewModel);
        }

        [ClaimsAuthorize("Supplier", "Delete")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Remove(Guid id)
        {
            var supplierViewModel = await GetSupplierWithAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            await _supplierService.Remove(id);

            return CustomResponse(supplierViewModel);
        }

        [AllowAnonymous]
        [HttpGet("address/{id:guid}")]
        public async Task<AddressViewModel> GetAddressById(Guid id)
        {
            return _mapper.Map<AddressViewModel>(await _addressRepository.GetById(id));
        }

        [ClaimsAuthorize("Supplier", "Update")]
        [HttpPut("address/{id:guid}")]
        public async Task<ActionResult> UpdateAddress(Guid id, AddressViewModel addressViewModel)
        {
            if (id != addressViewModel.Id)
            {
                NotifyError("Invalid resource");
                return CustomResponse(addressViewModel);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _supplierService.UpdateAddress(_mapper.Map<Address>(addressViewModel));

            return CustomResponse(addressViewModel);
        }

        private async Task<SupplierViewModel> GetSupplierWithAddressAndProducts(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierWithAddressAndProducts(id));
        }

        private async Task<SupplierViewModel> GetSupplierWithAddress(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierWithAddress(id));
        }
    }
}
