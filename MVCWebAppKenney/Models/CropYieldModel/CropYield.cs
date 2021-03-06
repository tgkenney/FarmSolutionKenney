﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models
{
    public class CropYield
    {
        [Key]
        public int CropYieldID { get; set; }
        public double ProductionAmount { get; set; }
        public int ProductionYear { get; set; }

        // Link to Crop
        [Required(ErrorMessage = "A crop is required")]
        public int CropID { get; set; }
        [ForeignKey("CropID")]
        public Crop Crop { get; set; }

        // Link to Farm
        [Required(ErrorMessage = "A farm is required")]
        public int FarmID { get; set; }
        [ForeignKey("FarmID")]
        public Farm Farm { get; set; }
    }
}
