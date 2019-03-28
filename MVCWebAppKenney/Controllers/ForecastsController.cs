using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Data;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.ViewModels;

namespace MVCWebAppKenney.Controllers
{
    
    public class ForecastsController : Controller
    {
        private ApplicationDbContext database;

        // Constructor
        // Dependency Injection
        public ForecastsController(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        [HttpGet]
        public IActionResult SearchDemandForecasts()
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");

            return View();
        }
        [HttpPost]
        public IActionResult SearchDemandForecasts(SearchForecastsViewModel model)
        {
            return View();
        }

        public IActionResult ListAllForecasts()
        {
            List<Crop> cropList = database.Crops.Include(c => c.Forecasts).ToList<Crop>();

            return View(cropList);
        }
    }
}