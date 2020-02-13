namespace Andreys.App.Controllers
{
    using Andreys.Services.Interfaces;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (IsUserLoggedIn())
            {
                var viewModel = this.productsService.GetAll();

                var products = new ProductsViewModel
                { Products = viewModel };

                return this.View(products, "/Home");
            }

            return this.View();
        }
    }
}
