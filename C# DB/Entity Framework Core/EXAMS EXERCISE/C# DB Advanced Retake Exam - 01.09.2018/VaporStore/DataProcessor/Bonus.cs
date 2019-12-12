namespace VaporStore.DataProcessor
{
    using System;
    using System.Linq;
    using Data;

    public static class Bonus
    {
        public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
        {
            var currentUser =
                context.Users
                .FirstOrDefault(u => u.Username == username);

            var userWithEmail = context.Users.FirstOrDefault(u => u.Email == newEmail);

            if (currentUser == null)
            {
                return $"User {username} not found";
            }

            
            else if (userWithEmail == null)
            {
                currentUser.Email = newEmail;
                context.SaveChanges();
                return $"Changed {username}'s email successfully";
            }


           
                return $"Email {newEmail} is already taken";
                
            

        }
    }
}
