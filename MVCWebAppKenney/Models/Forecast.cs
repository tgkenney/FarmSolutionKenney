using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models
{
    public class Forecast
    {
        [Key]
        public int ForecastID { get; set; }
        public double ForecastAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double? ActualSales { get; set; }

        public int CropID { get; set; }
        [ForeignKey("CropID")]
        public Crop Crop { get; set; }
    }
}
