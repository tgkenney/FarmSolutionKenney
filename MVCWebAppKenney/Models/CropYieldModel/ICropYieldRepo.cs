using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.CropYieldModel
{
    public interface ICropYieldRepo
    {
        // List used for searching
        IQueryable<CropYield> CropYieldList { get; }
        Task AddCropYield(CropYield cropYield);
        Task EditCropYield(CropYield cropYield);
    }
}
