
using Andreys.Services.Interfaces;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        public HttpResponse Add()
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductViewModel product)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/");
            }

            if (product.Name.Length < 4 & product.Name.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }
            if (product.Description.Length > 10)
            {
                return this.Redirect("/Products/Add");
            }

            this.productsService.AddProduct(product);


            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/");
            }

           var productViewModel = productsService.GetProduct(id);

            return this.View(productViewModel);

        }

        public HttpResponse Delete(int id)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/");
            }

            productsService.DelelteProduct(id);

            return Redirect("/");

        }

    }
}
