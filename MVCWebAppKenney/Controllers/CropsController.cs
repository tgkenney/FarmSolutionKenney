using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Data;
using MVCWebAppKenney.Models;

namespace MVCWebAppKenney.Controllers
{
    public class CropsController : Controller
    {
        // Private attribute for the database
        private ApplicationDbContext database;

        public CropsController(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        [HttpGet]
        public IActionResult SearchCrops()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchCrops(int ClassificationID)
        {
            return View();
        }

        public IActionResult ListAllCrops()
        {
            List<Crop> cropList = database.Crops.Include(c => c.Classification).ToList<Crop>();

            return View(cropList);
        }
    }
}