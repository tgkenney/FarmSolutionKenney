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

        public Task EditForecast(Forecast forecast)
        {
            database.Forecasts.Update(forecast);

            return database.SaveChangesAsync();
        }

        public Forecast FindDemandForecast(int forecastId)
        {
            Forecast forecast = database.Forecasts.Find(forecastId);

            return forecast;
        }

        public List<Forecast> GetForecastsWithoutActualSales()
        {
            List<Forecast> forecastList = new List<Forecast>();

            forecastList = database.Forecasts
                .Include(f => f.Crop)
                .ThenInclude(c => c.Classification)
                .Where(f => f.ActualSales == null)
                .ToList();

            return forecastList;
        }
    }
}
