using IRunesApp.Services.Interfaces;
using IRunesApp.ViewModels.Home;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (IsUserLoggedIn())
            {
                var viewModel = new HomeViewModel
                {
                    Username = usersService.GetUsername(User)
                };
                return this.View(viewModel, "Home");
            }

            return this.View();
        }

    }
}
