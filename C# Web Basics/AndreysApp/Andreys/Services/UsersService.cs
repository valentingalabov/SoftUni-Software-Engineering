using Andreys.Data;
using Andreys.Models;
using Andreys.Services.Interfaces;
using Andreys.ViewModels.Users;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Andreys.Services
{
    public class UsersService : IUsersService
    {
        private readonly AndreysDbContext db;

        public UsersService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(RegisterViewModel user)
        {
            var hashPassword = Hash(user.Password);

            var userToCreate = new User
            {
                Username = user.Username,
                Password = hashPassword,
                Email = user.Email,
                Role = IdentityRole.User
            };

            db.Users.Add(userToCreate);

            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = Hash(password);

            return db.Users
                    .Where(u => u.Username == username & u.Password == hashPassword)
                    .Select(u=>u.Id)
                    .FirstOrDefault();

      


        }

        public bool IsEmailExist(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }

        public bool IsUernameExist(string username)
        {
            return db.Users.Any(u => u.Username == username);
        }

        private string Hash(string input)
        {
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
