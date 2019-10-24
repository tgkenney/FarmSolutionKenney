using MVCWebAppKenney.ViewModels;
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
        List<Crop> SearchCrops(int? classficationID);
        // When altering or changing data (add,edit,delete)
        // Recommendation is to use async instead of synchronous
        // Async methods, return type is a task
        // whether or not the task is completed
        Task AddCrop(Crop crop);
        Task EditCrop(Crop crop);
        Task DeleteCrop(int cropID);
        SearchCropYieldsViewModel SearchCropYields(SearchCropYieldsViewModel model);

        /*
         * 1. AddCrop()
         * 2. EditCrop()
         * 3. DeleteCrop()
         * 4. FindCrop()
         */
    }
}
