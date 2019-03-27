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
    public class ClassificationsController : Controller
    {
        private ApplicationDbContext database;

        public ClassificationsController(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }
        public IActionResult ListAllClassificationCrops()
        {
            List<Classification> classificationsList = database.Classifications.Include(c => c.Crops).ToList<Classification>();
            return View(classificationsList);
        }
    }
}