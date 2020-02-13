using SIS.MvcFramework;
using System;

namespace IRunesApp.Models
{
    public class User :IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
