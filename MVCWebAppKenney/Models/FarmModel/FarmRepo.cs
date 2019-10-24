using MVCWebAppKenney.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.FarmModel
{
    public class FarmRepo : IFarmRepo
    {
        // Private attribute for the database variable
        private ApplicationDbContext database;

        public FarmRepo(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public Task AddFarm(Farm farm)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFarm(int farmID)
        {
            throw new NotImplementedException();
        }

        public Task EditFarm(Farm farm)
        {
            throw new NotImplementedException();
        }

        public List<Farm> ListAllFarms()
        {
            List<Farm> farmList = database.Farms.ToList<Farm>();

            return farmList;
        }

        public int FindFarmOfFarmer(string userID)
        {
            int farmID = database.Farmers.Find(userID).FarmID;

            return farmID;
        }
    }
}
