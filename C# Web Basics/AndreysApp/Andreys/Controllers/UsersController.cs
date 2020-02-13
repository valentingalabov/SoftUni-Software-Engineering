using Andreys.Services.Interfaces;
using Andreys.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (IsUserLoggedIn())
            {
                return Redirect("/");
            }

            var userId = usersService.GetUserId(username, password);

            if (userId == null)
            {
                return Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return Redirect("/");


        }

        public HttpResponse Register()
        {
            if (IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterViewModel user)
        {
            if (IsUserLoggedIn())
            {
                return Redirect("/");
            }

            if (user.Username.Length < 4 || user.Username.Length > 10)
            {
                return Redirect("/Users/Register");
            }
            if (user.Password.Length < 6 || user.Password.Length > 20)
            {
                return Redirect("/Users/Register");
            }
            if (user.Password != user.ConfirmPassword)
            {
                return Redirect("/Users/Register");
            }

            if (usersService.IsUernameExist(user.Username))
            {
                return Redirect("/Users/Register");
            }
            if (usersService.IsEmailExist(user.Email))
            {
                return Redirect("/Users/Register");
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                return Redirect("/Users/Register");
            }


            this.usersService.CreateUser(user);

            return this.View();
        }

        public HttpResponse Logout()
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/");
            }
            SignOut();
            return Redirect("/");
        }

    }
}
