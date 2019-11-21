using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public void PopulateDropdowns()
        {
            ViewData["AppUsers"] = new SelectList(database.ApplicationUsers.OrderBy(a => a.LastName).ToList<ApplicationUser>(), "Id", "FullName");
        }

        // JavaScript Object Notation (JSON)
        public string GetCurrentRoles(string id)
        {
            var userRoleList =
                from UR in database.UserRoles
                join R in database.Roles
                on UR.RoleId equals R.Id
                where UR.UserId == id
                select new { R.Id, R.Name };
                 // LINQ for SQL

            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(userRoleList);

            return jsonData;
        }

        public string GetAvailableRoles(string id)
        {
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

            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(userRoleList);

            return jsonData;
        }

        [HttpGet]
        public IActionResult AssignAppUserRoles()
        {
            PopulateDropdowns();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignAppuserRoles(string submitButton)
        {
            string userID = Request.Form["ddlAppUsers"].ToString();
            ApplicationUser user = database.ApplicationUsers.Find(userID);

            List<string> selectedRoles = new List<string>();

            if (submitButton == "AddRoles")
            {
                selectedRoles = Request.Form["availableRoles"].ToList<string>();
                selectedRoles = selectedRoles.ConvertAll(s => s.Trim());

                await userManager.AddToRolesAsync(user, selectedRoles);
            }
            else if (submitButton == "RemoveRoles")
            {
                selectedRoles = Request.Form["currentRoles"].ToList<string>();
                selectedRoles = selectedRoles.ConvertAll(s => s.Trim());

                await userManager.RemoveFromRolesAsync(user, selectedRoles);
            }

            ViewData["AppUsers"] = new SelectList(database.ApplicationUsers.OrderBy(a => a.LastName).ToList<ApplicationUser>(), "Id", "FullName", userID);

            return View();
        }
    }
}