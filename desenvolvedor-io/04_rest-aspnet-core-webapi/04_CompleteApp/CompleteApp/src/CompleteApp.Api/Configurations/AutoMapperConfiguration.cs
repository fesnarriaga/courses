using AutoMapper;
using CompleteApp.Api.ViewModels;
using CompleteApp.Business.Models;

namespace CompleteApp.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<SupplierViewModel, Supplier>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();

            CreateMap<ProductViewModel, Product>().ReverseMap();
            //CreateMap<ProductViewModel, Product>();
            //CreateMap<Product, ProductViewModel>()
            //    .ForMember(
            //        dest => dest.SupplierName,
            //        opt =>
            //            opt.MapFrom(src => src.Supplier.Name));

            CreateMap<ProductViewModelIFormFile, Product>().ReverseMap();
        }
    }
}
