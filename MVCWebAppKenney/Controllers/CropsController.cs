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

            // IQueryable<CropYield> cropYieldsList = database.CropYields.Include(cY => cY.Crop).

            return View(model);
        }
    }
}