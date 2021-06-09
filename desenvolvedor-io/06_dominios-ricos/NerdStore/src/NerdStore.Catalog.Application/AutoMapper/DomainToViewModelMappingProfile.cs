using AutoMapper;
using NerdStore.Catalog.Application.ViewModels;
using NerdStore.Catalog.Domain.Entities;

namespace NerdStore.Catalog.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(vm => vm.Width, op => op.MapFrom(src => src.Dimensions.Width))
                .ForMember(vm => vm.Height, op => op.MapFrom(src => src.Dimensions.Height))
                .ForMember(vm => vm.Depth, op => op.MapFrom(src => src.Dimensions.Depth));

            CreateMap<Category, CategoryViewModel>();
        }
    }
}
