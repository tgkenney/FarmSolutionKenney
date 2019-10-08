using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.CropYieldModel
{
    public class CropYieldRepo : ICropYieldRepo
    {
        // Private attribute for the database variable
        private ApplicationDbContext database;

        public CropYieldRepo(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public IQueryable<CropYield> CropYieldList
        {
            get
            {
                IQueryable<CropYield> cropYieldList = database.CropYields.Include(c => c.Crop);

                return cropYieldList;
            }
        }

        public Task AddCropYield(CropYield cropYield)
        {
            database.CropYields.AddAsync(cropYield);

            return database.SaveChangesAsync();
        }

        public Task EditCropYield(CropYield cropYield)
        {
            database.CropYields.Update(cropYield);

            return database.SaveChangesAsync();
        }
        
        public Task DeleteCropYield(int? cropYieldID)
        {
            CropYield cropYield = database.CropYields.Find(cropYieldID);
            database.CropYields.Remove(cropYield);

            return database.SaveChangesAsync();
        }
    }
}
