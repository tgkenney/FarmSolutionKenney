using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCWebAppKenney.Controllers;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.CropModel;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestProjectKenney
{
    public class CropUnitTest
    {
        [Fact]
        public void ShouldReturnViewForListAllCrops()
        {
            Mock<ICropRepo> mockCropRepo = new Mock<ICropRepo>();
            List<Crop> mockCropList = PopulateCrops();

            mockCropRepo.Setup(m => m.ListAllCrops()).Returns(mockCropList);

            CropsController cropsController = new CropsController(mockCropRepo.Object);

            IActionResult result = cropsController.ListAllCrops();

            

        }

        private List<Crop> PopulateCrops()
        {
            List<Crop> cropList = new List<Crop>();

            Crop crop = new Crop
            {
                CropName = "Apple",
                CropVariety = null,
                ClassificationID = 1
            };
            cropList.Add(crop);

            crop = new Crop
            {
                CropName = "Bok Choi",
                CropVariety = null,
                ClassificationID = 2
            };
            cropList.Add(crop);

            crop = new Crop
            {
                CropName = "Basil",
                CropVariety = null,
                ClassificationID = 3
            };
            cropList.Add(crop);

            return cropList;
        }
    }
}
