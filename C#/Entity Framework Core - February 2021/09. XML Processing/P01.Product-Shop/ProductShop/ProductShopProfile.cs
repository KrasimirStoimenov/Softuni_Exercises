using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<ProductDto, Product>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryProductDto, CategoryProduct>();

            CreateMap<Product, ExportProductDto>()
                .ForMember(x => x.BuyerName, y => y.MapFrom(b => b.Buyer.FirstName + " " + b.Buyer.LastName));
        }
    }
}
