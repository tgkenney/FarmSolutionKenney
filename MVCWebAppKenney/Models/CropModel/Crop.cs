using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models
{
    public class Crop
    {
        [Key]
        public int CropID { get; set; }
        public string CropName { get; set; }
        public string CropVariety { get; set; }

        // Link to classification is below

        // Relational Database: Foriegn key for Navigation
        public int ClassificationID { get; set; }
        // Object-Oriented: How to navigate? 
        //Entity Framework is an Object Relational Mapper (ORM)
        [ForeignKey("ClassificationID")]
        public Classification Classification { get; set; }

        public List<Forecast> Forecasts { get; set; }
        public List<CanProduce> FarmsThatCanProduce { get; set; }
    }
}
