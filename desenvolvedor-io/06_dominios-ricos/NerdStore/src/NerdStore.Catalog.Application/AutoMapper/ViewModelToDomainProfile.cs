using AutoMapper;
using NerdStore.Catalog.Application.ViewModels;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.DomainObjects.ValueObjects;

namespace NerdStore.Catalog.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ProductViewModel, Product>()
                .ConstructUsing(vm => new Product(
                    vm.Name,
                    vm.Description,
                    vm.Price,
                    vm.Image,
                    new Dimensions(vm.Width, vm.Height, vm.Depth),
                    vm.Active,
                    vm.CreatedAt,
                    vm.CategoryId));

            CreateMap<CategoryViewModel, Category>()
                .ConstructUsing(vm => new Category(vm.Name, vm.Code));
        }
    }
}
