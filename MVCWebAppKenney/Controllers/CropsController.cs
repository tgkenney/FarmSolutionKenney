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

        // If Farmer, return their FarmID
        // After validation, returns the UserID as well
        public int ValidateUser(out string userID) // Output parameter
        {
            userID = null;
            int farmID = 0;

            if (User.Identity.IsAuthenticated)
            {
                userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (User.IsInRole("Farmer"))
                {
                    farmID = farmRepoInterface.FindFarmOfFarmer(userID);
                }
            }

            return farmID;
        }

        public SearchCropYieldsViewModel SearchCropYieldsHelper(SearchCropYieldsViewModel model, int farmID)
        {
            IQueryable<CropYield> cropYieldsList = cropYieldRepoInterface.CropYieldList;

            // Search by Farm
            if (farmID != 0)
            {
                cropYieldsList = cropYieldsList.Where(cY => cY.FarmID == model.FarmID);
            }
            if (farmID == 0)
            {
                if (model.FarmID != null)
                {
                    cropYieldsList = cropYieldsList.Where(cY => cY.FarmID == model.FarmID);
                }
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

            return model;
        }

        public List<GroupingViewModel> Grouping(List<CropYield> cropYieldList)
        {
            List<GroupingViewModel> groupingList = new List<GroupingViewModel>();

            groupingList = cropYieldList.GroupBy(c => new { c.CropID, c.FarmID }).Select(gvm => new GroupingViewModel{ CropName = gvm.First().Crop.CropName, FarmName = gvm.First().Farm.FarmName, ProductionAmount = gvm.Sum(g => g.ProductionAmount) }).ToList<GroupingViewModel>();

            return groupingList;
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

            string userID = null;
            int farmID = ValidateUser(out userID);
            SearchCropYieldsViewModel resultModel = new SearchCropYieldsViewModel();

            if (userID != null)
            {
                resultModel = SearchCropYieldsHelper(model, farmID);

                resultModel.GroupingByFarmAndCrop = Grouping(resultModel.CropYieldList);
            }

            else
            {
                resultModel.CropYieldList = null;
                resultModel.GroupingByFarmAndCrop = null;
            }

            return View(resultModel);
        }

        [HttpGet]
        [Authorize(Roles = "Farmer")]
        public IActionResult AddCropYield()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Farmer")]
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