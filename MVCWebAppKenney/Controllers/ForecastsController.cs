using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Data;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.ForecastModel;
using MVCWebAppKenney.ViewModels;
using Newtonsoft.Json;

namespace MVCWebAppKenney.Controllers
{

    public class ForecastsController : Controller
    {
        private ApplicationDbContext database;
        private readonly IForecastRepo forecastRepoInterface;

        // Constructor
        // Dependency Injection
        public ForecastsController(ApplicationDbContext dbContext, IForecastRepo forecastRepo)
        {
            this.database = dbContext;
            this.forecastRepoInterface = forecastRepo;
        }

        public IActionResult GetForecastVSales()
        {
            return View();
        }

        public string GetForecastVSalesDataForChart()
        {
            var data = database.Forecasts
                .Include(f => f.Crop)
                .GroupBy(f => f.Crop.CropName)
                .Select(gvm => new ForecastVSalesGroupingViewModel
                {
                    CropName = gvm.First().Crop.CropName,
                    TotalDemandForecast = gvm.Sum(i => i.ForecastAmount),
                    TotalActualSales = gvm.Sum(i => i.ActualSales)
                });

            return JsonConvert.SerializeObject(data);
        }

        public IActionResult GetForecastsWithoutActualSales()
        {
            List<Forecast> forecastList = new List<Forecast>();

            forecastList = forecastRepoInterface.GetForecastsWithoutActualSales();

            return View(forecastList);
        }

        [HttpPost]
        public IActionResult UpdateMultipleForecasts()
        {
            var actualSalesList = Request.Form["actualSales"].ToList();
            var forecastIdList = Request.Form["forecastID"].ToList();

            for (int i = 0; i < actualSalesList.Count; i++)
            {
                Forecast forecast = database.Forecasts.Find(int.Parse(forecastIdList[i]));
                forecast.ActualSales = double.Parse(actualSalesList[i]);

                database.Forecasts.Update(forecast);
                database.SaveChanges();
            }

            return RedirectToAction("SearchDemandForecasts");
        }

        [HttpGet]
        [Authorize]
        public IActionResult SearchDemandForecasts()
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");

            SearchForecastsViewModel model = new SearchForecastsViewModel();

            return View(model);
        }
        [HttpPost]
        [Authorize]
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
        [Authorize(Roles = "Analyst")]
        public IActionResult AddDemandForecast()
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Analyst")]
        public IActionResult AddDemandForecast(Forecast demandForecast)
        {
            database.Forecasts.Add(demandForecast);
            database.SaveChanges();

            return RedirectToAction("SearchDemandForecasts");
        }

        [HttpGet]
        [Authorize(Roles = "Analyst")]
        public IActionResult EditDemandForecast(int? demandForecastID)
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");

            Forecast demandForecast = database.Forecasts.Find(demandForecastID);

            return View(demandForecast);
        }

        [HttpPost]
        [Authorize(Roles = "Analyst")]
        public IActionResult EditDemandForecast(Forecast demandForecast)
        {
            database.Forecasts.Update(demandForecast);
            database.SaveChanges();

            return RedirectToAction("SearchDemandForecasts");
        }

        [HttpGet]
        [Authorize(Roles = "Analyst")]
        public IActionResult DeleteDemandForecast(int? demandForecastID)
        {
            Forecast demandForecast = database.Forecasts.Find(demandForecastID);
            database.Remove(demandForecast);
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