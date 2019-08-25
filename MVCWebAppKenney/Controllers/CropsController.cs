using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Data;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.ViewModels;

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
        [Authorize]
        public IActionResult SearchCropYields()
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");
            ViewData["FarmList"] = new SelectList(database.Farms, "FarmID", "FarmName");

            SearchCropYieldsViewModel model = new SearchCropYieldsViewModel();

            return View(model);
        }
        [HttpPost]
        [Authorize]
        public IActionResult SearchCropYields(SearchCropYieldsViewModel model)
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");
            ViewData["FarmList"] = new SelectList(database.Farms, "FarmID", "FarmName");

            IQueryable<CropYield> cropYieldsList = database.CropYields.Include(cY => cY.Crop).Include(cY => cY.Farm);

            // Search by farm
            if (model.FarmID != null)
            {
                cropYieldsList = cropYieldsList.Where(cY => cY.FarmID == model.FarmID);
            }

            // Search by crop
            if (model.CropID != null)
            {
                cropYieldsList = cropYieldsList.Where(cY => cY.CropID == model.CropID);
            }

            // Search by year
            if (model.SearchProductionYear != null)
            {
                cropYieldsList = cropYieldsList.Where(cY => cY.ProductionYear == model.SearchProductionYear);
            }

            model.CropYieldList = cropYieldsList.ToList<CropYield>();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Farmer")]
        public IActionResult AddCropYield()
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");
            ViewData["FarmList"] = new SelectList(database.Farms, "FarmID", "FarmName");

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Farmer")]
        public IActionResult AddCropYield(CropYield cropYield)
        {
            database.CropYields.Add(cropYield);
            database.SaveChanges();

            return RedirectToAction("SearchCropYields");
        }

        [HttpGet]
        [Authorize(Roles = "Farmer")]
        public IActionResult EditCropYield(int? cropYieldID)
        {
            ViewData["CropList"] = new SelectList(database.Crops, "CropID", "CropName");
            ViewData["FarmList"] = new SelectList(database.Farms, "FarmID", "FarmName");

            CropYield cropYield = database.CropYields.Find(cropYieldID);

            return View(cropYield);
        }
        [HttpPost]
        [Authorize(Roles = "Farmer")]
        public IActionResult EditCropYield(CropYield cropYield)
        {
            database.CropYields.Update(cropYield);
            database.SaveChanges();

            return RedirectToAction("SearchCropYields");
        }

        [HttpGet]
        [Authorize(Roles = "Farmer")]
        public IActionResult DeleteCropYield(int? cropYieldID)
        {
            CropYield cropYield = database.CropYields.Find(cropYieldID);
            database.Remove(cropYield);
            database.SaveChanges();

            return RedirectToAction("SearchCropYields");
        }
    }
}