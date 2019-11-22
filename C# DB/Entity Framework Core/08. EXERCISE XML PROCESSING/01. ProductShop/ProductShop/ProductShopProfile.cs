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
            this.CreateMap<ImportUsersDto, User>();

            this.CreateMap<ImportProductDto, Product>();

            this.CreateMap<ImportCategoryDto, Category>();

            this.CreateMap<ImportCategoryAndProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductsInPriceRangeDto>();

            this.CreateMap<User, ExportUsersWithSoldProductsDto>();
            this.CreateMap<Product, ExportSoldProductsDto>();


            this.CreateMap<Category, ExportCategoryDto>();
        }
    }
}
