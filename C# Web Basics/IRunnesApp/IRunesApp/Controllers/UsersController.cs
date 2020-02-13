using IRunesApp.Services.Interfaces;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunesApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Register()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(string username, string password, string confirmPassword, string email)
        {
            if (username.Length > 10 || username.Length < 4)
            {
                return this.Error("Username must be in range [4-10]");
            }
            if (password.Length > 20 || password.Length < 6)
            {
                return this.Error("Password must be in range [6-20]");
            }
            if (usersService.UsernameExists(username))
            {
                return this.Error("Username already exist");
            }
            if (this.usersService.EmailExists(email))
            {
                return this.Error("Email address already exist!");
            }
            if (confirmPassword != password)
            {
                return this.Error("Password and confirm password must be the same");
            }


            usersService.Register(username, password, email);

            return Redirect("/Users/Login");
        }


        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = usersService.GetUserId(username, password);
            if (userId == null)
            {
                return Redirect("Users/Login");
            }

            SignIn(userId);

            return Redirect("/");

        }

        public HttpResponse Logout()
        {            
            this.SignOut();

            return Redirect("/");
        
        }

    }
}
