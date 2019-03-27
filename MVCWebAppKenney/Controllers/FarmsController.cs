using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebAppKenney.Data;
using MVCWebAppKenney.Models;

namespace MVCWebAppKenney.Controllers
{
    public class FarmsController : Controller
    {
        private ApplicationDbContext database;

        public FarmsController(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }
        public IActionResult ListAllFarms()
        {
            List<Farm> farmList = database.Farms.ToList<Farm>();

            return View(farmList);
        }
    }
}