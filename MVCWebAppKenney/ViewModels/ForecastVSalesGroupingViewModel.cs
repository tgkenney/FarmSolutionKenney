using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.ViewModels
{
    public class ForecastVSalesGroupingViewModel
    {
        public string CropName { get; set; }
        public double TotalDemandForecast { get; set; }
        public double? TotalActualSales { get; set; }
    }
}
