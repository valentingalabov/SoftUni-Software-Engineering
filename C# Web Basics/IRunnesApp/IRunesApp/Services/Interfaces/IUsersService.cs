namespace IRunesApp.Services.Interfaces
{
    public interface IUsersService
    {
        public void Register(string username, string password, string email);

        public bool UsernameExists(string username);

        public bool EmailExists(string email);

        public string GetUserId(string username,string password);

        public string GetUsername(string id);

    }
}
