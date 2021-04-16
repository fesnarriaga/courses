using CompleteApp.Business.Interfaces.Services;
using CompleteApp.Business.Models;
using CompleteApp.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        public async Task Add(Product product)
        {
            if (!Validate(new ProductValidation(), product))
                return;
        }

        public async Task Update(Product product)
        {
            if (!Validate(new ProductValidation(), product))
                return;
        }

        public async Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
