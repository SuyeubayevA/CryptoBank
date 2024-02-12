using AutoMapper;
using Pharmacy.Domain.Core;
using Pharmacy.Infrastructure.Data.DTO;

namespace Pharmacy.Profiles
{
    public class PharmacyModelsToDTOMappingProfile : Profile
    {
        public PharmacyModelsToDTOMappingProfile() 
        {
            CreateMap<Product, ProductDetailDTO>()
                .ForMember(dest => dest.ProductTypeName, act => act.MapFrom(src => src.ProductType != null ? src.ProductType.Name : null))
                .ForMember(dest => dest.ProductTypeProperties, act => act.MapFrom(src => src.ProductType != null ? src.ProductType.Properties : null))
                .ForMember(dest => dest.Sales, act => act.MapFrom(src => src.SalesInfo!=null ? src.SalesInfo.Sales : 0))
                .ForMember(dest => dest.ProductReminder, act => act.MapFrom(src => src.SalesInfo != null ? src.SalesInfo.ProductReminder : 0))
                .ForMember(dest => dest.CreatedDate, act => act.MapFrom(src => src.SalesInfo.CreatedDate))
                .ForMember(dest => dest.EditDate, act => act.MapFrom(src => src.SalesInfo.EditDate))
                .ForMember(dest => dest.ProductAmounts, act => act.MapFrom(src => src.ProductAmounts))
                .ReverseMap();

            CreateMap<Product, ProductDTO>()
                .ReverseMap();
            CreateMap<ProductType, ProductTypeDetailsDTO>()
                .ReverseMap();

            CreateMap<ProductType, ProductTypeDTO>()
                .ReverseMap();
            CreateMap<ProductType, ProductTypeDetailsDTO>()
                .ReverseMap();

            CreateMap<ProductAmount, ProductAmountDTO>()
                .ReverseMap();
            CreateMap<ProductAmount, ProductAmountDetailsDTO>()
                .ReverseMap();

            CreateMap<SalesInfo, SalesInfoDTO>()
                .ReverseMap();
            CreateMap<SalesInfo, SalesInfoDetailsDTO>()
                .ReverseMap();

            CreateMap<Warehouse, WarehouseDetailsDTO>()
                .ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>()
                .ReverseMap();
        }
    }
}
