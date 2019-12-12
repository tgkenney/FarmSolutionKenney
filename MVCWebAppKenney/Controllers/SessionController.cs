using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Data;
using MVCWebAppKenney.Models.Analyst;
using MVCWebAppKenney.Models.FarmModel;

namespace MVCWebAppKenney.Controllers
{
    public class SessionController : Controller
    {
        private ApplicationDbContext database;
        private IFarmRepo farmRepo;

        public SessionController(ApplicationDbContext dbContext, IFarmRepo farmRepo)
        {
            this.database = dbContext;
            this.farmRepo = farmRepo;
        }

        public IActionResult ListAllAnalysts()
        {
            var analystList = database.Analysts.ToList();

            return View(analystList);
        }

        [Authorize(Roles = "Farmer")]
        public IActionResult ListAllCropsGrownByMyFarm(string analystID)
        {
            HttpContext.Session.SetString("AnalystID", analystID);
            
            var userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var farmID = farmRepo.FindFarmOfFarmer(userID);

            ViewData["FarmName"] = database.Farms.Find(farmID).FarmName;

            var canProduceList = database.CanProduce
                .Include(cp => cp.Crop)
                .Where(cp => cp.FarmID == farmID)
                .ToList();

            return View(canProduceList);
        }

        public IActionResult ForecastsByAnalystForCrop(int cropID)
        {
            var analystID = HttpContext.Session.GetString("AnalystID");

            var forecastList = database.Forecasts
                .Include(f => f.Analyst)
                .Include(f => f.Crop)
                .Where(f => f.CropID == cropID && f.Id == analystID)
                .ToList();

            return View(forecastList);
        }
    }
}