using System;
using System.Collections.Generic;
using System.Globalization;
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

            SearchForecastsViewModel model = new SearchForecastsViewModel();

            return View(model);
        }
        [HttpPost]
        public IActionResult SearchDemandForecasts(SearchForecastsViewModel model)
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");

            IQueryable<Forecast> forecastList = database.Forecasts.Include(f => f.Crop).ThenInclude(c => c.Classification);
            //.ToList<Forecast>(); ToList gets data from the databse
            //.Include(d => d.Crop.Classification)

            if (model.ClassificationID != null)
            {
                forecastList = forecastList.Where(f => f.Crop.ClassificationID == model.ClassificationID);
            }


            // Do it for Crop as well
            if (model.CropID != null)
            {
                forecastList = forecastList.Where(f => f.Crop.CropID == model.CropID);
            }

            // Start and End date searching
            if (model.StartSearchDate != null)
            {
                forecastList = forecastList.Where(f => f.StartDate >= model.StartSearchDate.Value.Date);
            }
            if (model.EndSearchDate != null)
            {
                forecastList = forecastList.Where(f => f.EndDate <= model.EndSearchDate.Value.Date);
            }

            model.ForecastList = forecastList.ToList<Forecast>();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddDemandForecast()
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");

            return View();
        }
        [HttpPost]
        public IActionResult AddDemandForecast(Forecast demandForecast)
        {
            database.Forecasts.Add(demandForecast);
            database.SaveChanges();

            return RedirectToAction("SearchDemandForecasts");
        }

        

        public IActionResult ListAllForecasts()
        {
            List<Crop> cropList = database.Crops.Include(c => c.Forecasts).ToList<Crop>();

            return View(cropList);
        }
    }
}