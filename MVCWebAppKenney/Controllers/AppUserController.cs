using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCWebAppKenney.Data;
using MVCWebAppKenney.Models;

namespace MVCWebAppKenney.Controllers
{
    public class AppUserController : Controller
    {
        // Services
        private ApplicationDbContext database;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        
        public AppUserController(ApplicationDbContext database, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.database = database;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // JavaScript Object Notation (JSON)
        public string GetCurrentRoles(string id)
        {
            string jsonData = null;

            var userRoleList =
                from R in database.Roles
                where !
                (
                    from UR in database.UserRoles
                    where UR.UserId == id
                    select UR.RoleId
                )
                .Contains(R.Id)
                select new { R.Id, R.Name }; // LINQ for SQL

            jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(userRoleList);

            return jsonData;
        }
    }
}