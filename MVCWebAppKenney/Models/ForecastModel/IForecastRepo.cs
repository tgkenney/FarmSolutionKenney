using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.ForecastModel
{
    public interface IForecastRepo
    {
        // List for searching
        IQueryable<Forecast> ForecastList { get; }
        List<Forecast> GetForecastsWithoutActualSales();
        Forecast FindDemandForecast(int forecastId);
        Task EditForecast(Forecast forecast);
    }
}
