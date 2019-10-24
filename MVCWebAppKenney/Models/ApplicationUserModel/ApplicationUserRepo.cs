using MVCWebAppKenney.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.ApplicationUserModel
{
    public class ApplicationUserRepo : IApplicationUserRepo
    {
        private ApplicationDbContext database;

        public ApplicationUserRepo(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public List<ApplicationUser> ListAllUsers()
        {
            List<ApplicationUser> userList = database.ApplicationUsers.ToList<ApplicationUser>();

            return userList;
        }
    }
}
