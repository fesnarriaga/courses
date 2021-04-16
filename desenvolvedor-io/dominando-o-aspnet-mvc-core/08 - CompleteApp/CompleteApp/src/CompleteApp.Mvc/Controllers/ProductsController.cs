using AutoMapper;
using CompleteApp.Business.Interfaces;
using CompleteApp.Business.Models;
using CompleteApp.Mvc.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CompleteApp.Business.Interfaces.Repositories;

namespace CompleteApp.Mvc.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ProductsController(
            IMapper mapper,
            IProductRepository productRepository,
            ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        [Route("products-list")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsWithSuppliers()));
        }

        [Route("product-details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var productViewModel = await GetProductWithSupplierAndSuppliersList(id);

            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        [Route("create-product")]
        public async Task<IActionResult> Create()
        {
            return View(await SetSuppliersList(new ProductViewModel()));
        }

        [Route("create-product")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await SetSuppliersList(productViewModel);

            if (!ModelState.IsValid)
                return View(productViewModel);

            productViewModel.ImageUrl = await UploadFile(productViewModel.Image);

            if (string.IsNullOrEmpty(productViewModel.ImageUrl))
                return View(productViewModel);

            await _productRepository.Create(_mapper.Map<Product>(productViewModel));

            return RedirectToAction(nameof(Index));
        }

        [Route("edit-product/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewModel = await GetProductWithSupplierAndSuppliersList(id);

            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        [Route("edit-product/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
                return NotFound();

            var product = _mapper.Map<ProductViewModel>(await _productRepository.GetProductWithSupplier(id));

            productViewModel.Supplier = product.Supplier;
            productViewModel.ImageUrl = product.ImageUrl;

            if (!ModelState.IsValid)
                return View(productViewModel);

            if (productViewModel.Image != null)
            {
                var imageUrl = await UploadFile(productViewModel.Image);

                if (string.IsNullOrEmpty(imageUrl))
                    return View(productViewModel);

                product.ImageUrl = imageUrl;
            }

            product.Name = productViewModel.Name;
            product.Description = productViewModel.Description;
            product.Price = productViewModel.Price;
            product.IsActive = productViewModel.IsActive;

            await _productRepository.Update(_mapper.Map<Product>(product));

            return RedirectToAction(nameof(Index));
        }

        [Route("delete-product/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productViewModel = await GetProductWithSupplierAndSuppliersList(id);

            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        [Route("delete-product/{id:guid}")]
        [HttpPost]
        [ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productViewModel = await GetProductWithSupplierAndSuppliersList(id);

            if (productViewModel == null)
                return NotFound();

            await _productRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProductViewModel> SetSuppliersList(ProductViewModel productViewModel)
        {
            productViewModel.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());

            return productViewModel;
        }

        private async Task<ProductViewModel> GetProductWithSupplierAndSuppliersList(Guid id)
        {
            var productViewModel = _mapper.Map<ProductViewModel>(await _productRepository.GetProductWithSupplier(id));

            await SetSuppliersList(productViewModel);

            return productViewModel;
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            if (file.Length <= 0)
                return null;

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "File name already exists");
                return null;
            }

            await using var fileStream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return fileName;
        }
    }
}
