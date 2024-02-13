using AutoMapper;
using Pharmacy.Domain.Core;
using Pharmacy.Models;

namespace Pharmacy.Profiles
{
    public class PharmacyMappingProfile : Profile
    {
        public PharmacyMappingProfile() 
        {
            CreateMap<Product, ProductModel>()
                .ReverseMap();

            CreateMap<ProductType, ProductTypeModel>()
                .ReverseMap();

            CreateMap<ProductAmount, ProductAmountModel>()
                .ReverseMap();

            CreateMap<SalesInfo, SalesInfoModel>()
                .ReverseMap();

            CreateMap<Warehouse, WarehouseModel>()
                .ReverseMap();
        }
    }
}
