using AutoMapper;
using CompleteApp.Api.ViewModels;
using CompleteApp.Business.Interfaces.Notifications;
using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Interfaces.Services;
using CompleteApp.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CompleteApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;

        public ProductsController(
            IMapper mapper,
            IProductService productService,
            IProductRepository productRepository,
            INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _productService = productService;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAllProductsWithSupplier());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
        {
            var productViewModel = await GetProductWithSupplier(id);

            if (productViewModel == null)
                return NotFound();

            return productViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var fileName = $"{Guid.NewGuid()}_{productViewModel.Image}";
            if (!UploadFile(productViewModel.ImageBase64, fileName))
                return CustomResponse(productViewModel);

            productViewModel.Image = fileName;

            await _productService.Add(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }

        //[DisableRequestSizeLimit]
        [RequestSizeLimit(4000000)]
        [HttpPost("i-form-file")]
        public async Task<ActionResult<ProductViewModel>> AddIFormFile([FromForm] ProductViewModelIFormFile productViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var filePrefix = $"{Guid.NewGuid()}_";
            if (!await UploadFileIFormFile(productViewModel.ImageIFormFile, filePrefix))
                return CustomResponse(productViewModel);

            productViewModel.Image = filePrefix + productViewModel.ImageIFormFile.FileName;

            await _productService.Add(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                NotifyError("Invalid resource");
                return CustomResponse(productViewModel);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _productService.Update(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> Remove(Guid id)
        {
            var productViewModel = await GetProductWithSupplier(id);

            if (productViewModel == null)
                return NotFound();

            await _productService.Remove(id);

            return CustomResponse(productViewModel);
        }

        private async Task<ProductViewModel> GetProductWithSupplier(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetProductWithSupplier(id));
        }

        private bool UploadFile(string file, string fileName)
        {
            if (string.IsNullOrEmpty(file))
            {
                NotifyError("Image file is required");
                return false;
            }

            var fileByteArray = Convert.FromBase64String(file);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            if (System.IO.File.Exists(filePath))
            {
                NotifyError("File already exists");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, fileByteArray);

            return true;
        }

        private async Task<bool> UploadFileIFormFile(IFormFile file, string filePrefix)
        {
            if (file == null || file.Length == 0)
            {
                NotifyError("Image file is required");
                return false;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", $"{filePrefix}{file.FileName}");

            if (System.IO.File.Exists(filePath))
            {
                NotifyError("File already exists");
                return false;
            }

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return true;
        }
    }
}
