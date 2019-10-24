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
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public double? ActualSales { get; set; }

        [Required(ErrorMessage = "A crop is required")]
        public int CropID { get; set; }
        [ForeignKey("CropID")]
        public Crop Crop { get; set; }

        // Link to Analyst
        [Required(ErrorMessage = "An analyst is required")]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public Analyst.Analyst Analyst { get; set; }
    }
}
