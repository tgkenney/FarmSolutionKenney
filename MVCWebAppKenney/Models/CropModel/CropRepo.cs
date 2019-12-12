﻿using Microsoft.AspNetCore.Mvc.Razor.Internal;
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
            List<Crop> cropList = database.Crops.Include(c => c.Classification).OrderBy(c => c.CropName).ToList<Crop>();

            return cropList;
        }

        public List<Crop> SearchCrops(int? classificationID)
        {
            List<Crop> cropList = database.Crops.Where(c => c.ClassificationID == classificationID).ToList<Crop>();

            return cropList;
        }

        public SearchCropYieldsViewModel SearchCropYields(SearchCropYieldsViewModel model)
        {
            IQueryable<CropYield> cropYieldsList = database.CropYields.Include(cY => cY.Crop).Include(cY => cY.Farm);

            // Search by farm
            if (model.FarmID != null)
                cropYieldsList = cropYieldsList.Where(cY => cY.FarmID == model.FarmID);

            // Search by crop
            if (model.CropID != null)
                cropYieldsList = cropYieldsList.Where(cY => cY.CropID == model.CropID);

            // Search by year
            if (model.SearchProductionYear != null)
                cropYieldsList = cropYieldsList.Where(cY => cY.ProductionYear == model.SearchProductionYear);


            return model;
        }

        public Task AddCrop(Crop crop)
        {
            database.Crops.AddAsync(crop);

            return database.SaveChangesAsync();
        }

        public Task EditCrop(Crop crop)
        {
            database.Crops.Update(crop);

            return database.SaveChangesAsync();
        }

        public Task DeleteCrop(int cropID)
        {
            Crop crop = database.Crops.Find(cropID);
            database.Crops.Remove(crop);

            return database.SaveChangesAsync();
        }
    } // end class
} // end namespace
