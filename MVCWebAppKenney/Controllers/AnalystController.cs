using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.Analyst;
using MVCWebAppKenney.Models.ApplicationUserModel;
using MVCWebAppKenney.Models.CropModel;
using MVCWebAppKenney.Models.CropYieldModel;
using MVCWebAppKenney.Models.FarmModel;
using MVCWebAppKenney.Models.ForecastModel;
using MVCWebAppKenney.ViewModels;

namespace MVCWebAppKenney.Controllers
{
    public class AnalystController : Controller
    {
        private IForecastRepo forecastRepoInterface;
        private ICropRepo cropRepoInterface;
        private IApplicationUserRepo applicationUserRepoInterface;
        private IAnalystRepo analystRepoInterface;

        public AnalystController(IApplicationUserRepo userRepo, IForecastRepo forecastRepo, ICropRepo cropRepo, IAnalystRepo analystRepo)
        {
            this.forecastRepoInterface = forecastRepo;
            this.cropRepoInterface = cropRepo;
            this.applicationUserRepoInterface = userRepo;
            this.analystRepoInterface = analystRepo;
        }

        public void PopulateDropDownList()
        {
            ViewData["CropList"] = new SelectList(cropRepoInterface.ListAllCrops(), "CropID", "CropName");
            ViewData["UserList"] = new SelectList(analystRepoInterface.ListAllAnalysts(), "Id", "LastName");
        }

        public SearchForecastsViewModel SearchForecastsHelper(SearchForecastsViewModel model)
        {
            IQueryable<Forecast> forecastList = forecastRepoInterface.ForecastList;

            if (model.ClassificationID != null)
            {
                forecastList = forecastList.Where(f => f.Crop.ClassificationID == model.ClassificationID);
            }

            if (model.Id != null)
            {
                forecastList = forecastList.Where(f => f.ApplicationUser.Id == model.Id);
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

            return model;
        }

        [HttpGet]
        public IActionResult SearchForecasts()
        {
            PopulateDropDownList();

            SearchForecastsViewModel model = new SearchForecastsViewModel();

            return View(model);
        }
        [HttpPost]
        public IActionResult SearchForecasts(SearchForecastsViewModel model)
        {
            PopulateDropDownList();

            SearchForecastsViewModel resultModel = new SearchForecastsViewModel();

            resultModel = SearchForecastsHelper(model);

            return View(resultModel);
        }
    }
}