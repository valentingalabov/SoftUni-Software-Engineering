using IRunesApp.Models;
using IRunesApp.Services.Interfaces;
using SIS.MvcFramework;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IRunesApp.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool EmailExists(string email)
        {
            return db.Users.Any(x => x.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = Hash(password);

            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashPassword);

            if (user == null)
            {
                return null;
            }
            return user.Id;
        }

        public string GetUsername(string id)
        {
            var username = this.db.Users
                .Where(x => x.Id == id)
                .Select(x => x.Username)
                .FirstOrDefault();
            return username;

        }

        public void Register(string username, string password, string email)
        {
            var hashPassword = Hash(password);


            var user = new User
            {
                Role = IdentityRole.User,
                Username = username,
                Password = hashPassword,
                Email = email

            };

            db.Users.Add(user);

            db.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }


    }
}
