using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.CropModel
{
    public interface ICropRepo
    {
        // List of actions or methods promised
        List<Crop> ListAllCrops();

        /*
         * 1. AddCrop()
         * 2. EditCrop()
         * 3. DeleteCrop()
         * 4. FindCrop()
         */
    }
}
