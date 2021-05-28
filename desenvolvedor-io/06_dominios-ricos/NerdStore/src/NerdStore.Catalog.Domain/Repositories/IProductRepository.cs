using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<IEnumerable<Product>> GetByCategory(string code);

        void Add(Product product);
        void Update(Product product);

        // Category
        Task<IEnumerable<Category>> GetCategories();

        void Add(Category category);
        void Update(Category category);
    }
}
