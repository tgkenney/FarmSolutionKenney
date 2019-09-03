using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Data;
using MVCWebAppKenney.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.CropModel
{
    public class CropRepo : ICropRepo
    {
        // Private attribute for the database variable
        private ApplicationDbContext database;

        public CropRepo(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public List<Crop> ListAllCrops()
        {
            List<Crop> cropList = database.Crops.Include(c => c.Classification).ToList<Crop>();

            return cropList;
        }

        
    } // end class
} // end namespace
