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
    
    public class ForecastsController : Controller
    {
        private ApplicationDbContext database;

        public ForecastsController(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public IActionResult ListAllForecasts()
        {
            List<Crop> cropList = database.Crops.Include(c => c.Forecasts).ToList<Crop>();

            return View(cropList);
        }
    }
}