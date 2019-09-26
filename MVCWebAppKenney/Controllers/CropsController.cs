using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Data;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.CropModel;
using MVCWebAppKenney.Models.CropYieldModel;
using MVCWebAppKenney.Models.FarmModel;
using MVCWebAppKenney.ViewModels;

namespace MVCWebAppKenney.Controllers
{
    public class CropsController : Controller
    {
        private ICropYieldRepo cropYieldRepoInterface;
        private ICropRepo cropRepoInterface;
        private IFarmRepo farmRepoInterface;

        public CropsController(ICropYieldRepo cropYieldRepo, ICropRepo cropRepo, IFarmRepo farmRepo)
        {
            this.cropRepoInterface = cropRepo;
            this.cropYieldRepoInterface = cropYieldRepo;
            this.farmRepoInterface = farmRepo;
        }

        public void PopulateDropDownList()
        {
            ViewData["CropList"] = new SelectList(cropRepoInterface.ListAllCrops(), "CropID", "CropName");
            ViewData["FarmList"] = new SelectList(farmRepoInterface.ListAllFarms(), "FarmID", "FarmName");
        }

        public SearchCropYieldsViewModel SearchCropYieldsHelper(SearchCropYieldsViewModel model)
        {
            IQueryable<CropYield> cropYieldsList = cropYieldRepoInterface.CropYieldList;

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

            model.TotalCropYield = 0;

            foreach (CropYield cropYield in model.CropYieldList)
            {
                model.TotalCropYield += cropYield.ProductionAmount;
            };

            return model;
        }

        public async Task AddCropYieldHelper(CropYield cropYield)
        {
            await cropYieldRepoInterface.AddCropYield(cropYield);
        }

        public IActionResult ListAllCrops()
        {
            List<Crop> cropList = cropRepoInterface.ListAllCrops();

            return View(cropList);
        }
        
        [HttpGet]
        public IActionResult SearchCrops()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SearchCrops(int? classificationID)
        {
            List<Crop> cropList = cropRepoInterface.SearchCrops(classificationID);

            return View(cropList);
        }

        [HttpGet]
        public IActionResult AddCrop()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCrop(Crop crop)
        {
            await cropRepoInterface.AddCrop(crop);

            return RedirectToAction("ListAllCrops");
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult SearchCropYields()
        {
            PopulateDropDownList();

            SearchCropYieldsViewModel model = new SearchCropYieldsViewModel();

            return View(model);
        }
        [HttpPost]
        [Authorize]
        public IActionResult SearchCropYields(SearchCropYieldsViewModel model)
        {
            PopulateDropDownList();

            SearchCropYieldsViewModel resultModel = SearchCropYieldsHelper(model);

            return View(resultModel);
        }

        [HttpGet]
        public IActionResult AddCropYield()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCropYield(CropYield cropYield)
        {
            await AddCropYieldHelper(cropYield);

            return RedirectToAction("ListAllCrops");
        }

        /*
        [HttpGet]
        [Authorize(Roles = "Farmer")]
        public IActionResult AddCropYield()
        {
            PopulateDropDownList();

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
            PopulateDropDownList();

            CropYield cropYield = database.CropYields.Find(cropYieldID);

            return View(cropYield);
        }
       
        [HttpPost]
        [Authorize(Roles = "Farmer")]
        public IActionResult EditCropYield(CropYield cropYield)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Farmer farmer = database.Users.Find(userID) as Farmer;

            if (farmer.FarmID == cropYield.FarmID)
            {
                database.CropYields.Update(cropYield);
                database.SaveChanges();
            }

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
        */
    }
}