using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.ViewModels
{
    public class SearchCropsViewModel
    {
        public int ClassificationID { get; set; }
        public int CropID { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartSearchDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndSearchDate { get; set; }

    }
}
