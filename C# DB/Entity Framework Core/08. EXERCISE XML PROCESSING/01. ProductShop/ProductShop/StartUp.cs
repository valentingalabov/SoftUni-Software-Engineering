using ProductShop.Data;
using System;
using System.IO;
using System.Xml.Serialization;
using ProductShop.Dtos.Import;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //string InputXML = File.ReadAllText("./../../../Datasets/categories-products.xml");

                var result = GetProductsInRange(db);

                Console.WriteLine(result);
            }


        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var XmlSerializer = new XmlSerializer(typeof(ImportUsersDto[]),
                                new XmlRootAttribute("Users"));

            ImportUsersDto[] userDtos;

            using (var reader = new StringReader(inputXml))
            {
                userDtos = (ImportUsersDto[])XmlSerializer.Deserialize(reader);
            }

            var users = Mapper.Map<User[]>(userDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";

        }

        //02. Import Products

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var XmlSerializer = new XmlSerializer(typeof(ImportProductDto[]),
                                new XmlRootAttribute("Products"));


            ImportProductDto[] productDtos;

            using (var reader = new StringReader(inputXml))
            {
                productDtos = (ImportProductDto[])XmlSerializer.Deserialize(reader);
            }

            var products = Mapper.Map<Product[]>(productDtos);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";

        }

        //03. Import Categories

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var XmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]),
                                new XmlRootAttribute("Categories"));

            ImportCategoryDto[] categoryDtos;

            using (var reader = new StringReader(inputXml))
            {
                categoryDtos = ((ImportCategoryDto[])XmlSerializer.Deserialize(reader))
                                .Where(c => c.Name != null)
                                .ToArray();
            }

            var categories = Mapper.Map<Category[]>(categoryDtos);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //04. Import Categories and Products

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var XmlSerializer = new XmlSerializer(typeof(ImportCategoryAndProductDto[]),
                                new XmlRootAttribute("CategoryProducts"));


            ImportCategoryAndProductDto[] categoryAndProductDtos;

            using (var reader = new StringReader(inputXml))
            {
                categoryAndProductDtos = (ImportCategoryAndProductDto[])XmlSerializer.Deserialize(reader);

            }

            var categoriesAndProducts = new List<CategoryProduct>();

            foreach (var cpDto in categoryAndProductDtos)
            {
                var categorie = context.Categories.Find(cpDto.CategoryId);
                var product = context.Products.Find(cpDto.ProductId);

                if (categorie == null && product == null)
                {
                    continue;
                }
                var mapper = Mapper.Map<CategoryProduct>(cpDto);

                categoriesAndProducts.Add(mapper);


            }

            context.CategoryProducts.AddRange(categoriesAndProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesAndProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var products =
                context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p=> new ExportProductsInPriceRangeDto
                { 
                    Name=p.Name,
                    Price=p.Price,
                    BuyerName= $"{p.Buyer.FirstName} {p.Buyer.LastName}"

                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductsInPriceRangeDto[]),
                                         new XmlRootAttribute("Products"));


            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, products, namespaces);
            }

            return sb.ToString().TrimEnd();


        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();


            var usersWithProducts =
                context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportUsersWithSoldProductsDto>()
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUsersWithSoldProductsDto[]),
                                          new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, usersWithProducts, namespaces);
            }

            return sb.ToString().TrimEnd();

        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();


            var categories =
               context
               .Categories
               .Select(c => new ExportCategoryDto
               {
                   Name = c.Name,
                   CountOfProducts = c.CategoryProducts.Count(),
                   AverageProductsPrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                   TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)

               })
               .OrderByDescending(c => c.CountOfProducts)
               .ThenBy(c => c.TotalRevenue)
               .ToArray();



            var XmlSerializer = new XmlSerializer(typeof(ExportCategoryDto[]),
                                new XmlRootAttribute("Categories"));


            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                XmlSerializer.Serialize(writer, categories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //08. Export Users and Products

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            StringBuilder sb = new StringBuilder();

            var users =
                context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUsersDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProductDto = new SoldProductDto
                    {
                        Count = u.ProductsSold.Count,
                        ProductDto = u.ProductsSold.Select(p => new ProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .ToArray()
                .OrderByDescending(u => u.SoldProductDto.Count)
                .Take(10)
                .ToArray();

            var export = new ExportCustomUserProductDto
            {
                Count = context
              .Users
              .Count(u => u.ProductsSold.Any()),
                Users = users
            };

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomUserProductDto),
                                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, export, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

    }
}