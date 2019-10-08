using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.ForecastModel
{
    public class ForecastRepo : IForecastRepo
    {
        // Private attribute for the database variable
        private ApplicationDbContext database;

        public ForecastRepo(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public IQueryable<Forecast> ForecastList
        {
            get
            {
                IQueryable<Forecast> forecastList = database.Forecasts;
                
                return forecastList;
            }
        }
    }
}
