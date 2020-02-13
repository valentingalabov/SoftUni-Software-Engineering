using Andreys.ViewModels.Users;

namespace Andreys.Services.Interfaces
{
    public interface IUsersService
    {
        public void CreateUser(RegisterViewModel user);

        public string GetUserId(string username, string password);

        public bool IsUernameExist(string username);

        public bool IsEmailExist(string email);




    }
}
