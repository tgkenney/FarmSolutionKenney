using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models
{
    public class CanProduce
    {
        [Key]
        public int CanProduceID { get; set; }

        public int CropID { get; set; }
        [ForeignKey("CropID")]
        public Crop Crop { get; set; }
        
        public int FarmID { get; set; }
        [ForeignKey("FarmID")]
        public Farm Farm { get; set; }
    }
}
