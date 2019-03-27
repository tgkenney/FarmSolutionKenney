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
    public class CanProduceController : Controller
    {
        private ApplicationDbContext database;

        public CanProduceController(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public IActionResult ListAllCanProduce()
        {
            List<CanProduce> produceList = database.CanProduce.Include(c => c.Crop).Include(c => c.Farm).ToList<CanProduce>();

            return View(produceList);
        }

        public IActionResult ListAllFarmsAndCrops()
        {
            List<Farm> farmList = database.Farms.Include(f => f.CropsThatCanBeProduced).ThenInclude(c => c.Crop).ToList<Farm>();

            return View(farmList);
        }
        public IActionResult ListAllCropsAndFarms()
        {
            List<Crop> cropList = database.Crops.Include(c => c.FarmsThatCanProduce).ThenInclude(cp => cp.Farm).ToList<Crop>();

            return View(cropList);
        }
    }
}