using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models
{
    public class Farm
    {
        [Key]
        public int FarmID { get; set; }
        public string FarmName { get; set; }
        public string FarmAddress { get; set; }
        public double FarmSize { get; set; }

        public List<CanProduce> CropsThatCanBeProduced { get; set; }
        public List<Farmer> FarmersThatWorkHere { get; set; }
    }
}
