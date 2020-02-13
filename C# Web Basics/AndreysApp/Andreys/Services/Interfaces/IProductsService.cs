using Andreys.ViewModels.Products;
using System.Collections.Generic;

namespace Andreys.Services.Interfaces
{
    public interface IProductsService
    {
        public IEnumerable<AllProductListngViewModel> GetAll();

        public void AddProduct(AddProductViewModel product);

        public ProductDetailViewModel GetProduct(int id);

        public void DelelteProduct(int id);
    }
}
