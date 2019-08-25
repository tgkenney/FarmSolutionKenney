using MVCWebAppKenney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.ViewModels
{
    public class SearchCropYieldsViewModel
    {
        // User inputs for search
        public int? CropID { get; set; }
        public int? FarmID { get; set; }
        public int? SearchProductionYear { get; set; }

        // Search result
        public List<CropYield> CropYieldList { get; set; }

    }
}
