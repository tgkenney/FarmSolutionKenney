using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ApplicationUser(string firstname, string lastname, string email, string phoneNumber, string password)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.UserName = email;

            // Password block - Required
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            this.PasswordHash = passwordHasher.HashPassword(this, password);
            // GUID - Required
            this.SecurityStamp = Guid.NewGuid().ToString();
        }

        public ApplicationUser() { } // Empty constructor for dotnet
    }
}
