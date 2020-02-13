using Andreys.Data;
using Andreys.Models;
using Andreys.Models.Enums;
using Andreys.Services.Interfaces;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void AddProduct(AddProductViewModel product)
        {
            var findCategory = Enum.TryParse(product.Category, out Category category);
            var findGender = Enum.TryParse(product.Gender, out Gender gender);

            var productToAdd = new Product
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Category = category,
                Gender = gender
            };

            db.Products.Add(productToAdd);
            db.SaveChanges();
        }

        public void DelelteProduct(int id)
        {
           var product= db.Products.FirstOrDefault(p => p.Id == id);

            db.Products.Remove(product);
            db.SaveChanges();

        }

        public IEnumerable<AllProductListngViewModel> GetAll()
        {

            return db.Products
                .Select(p => new AllProductListngViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                }).ToList();

        }

        public ProductDetailViewModel GetProduct(int id)
        {

           return db.Products.Where(p => p.Id == id)
                .Select(p => new ProductDetailViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category.ToString(),
                    Gender = p.Gender.ToString(),
                }).FirstOrDefault();
        }
    }
}
