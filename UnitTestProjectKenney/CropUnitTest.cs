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

            // Create CropsController object
            CropsController cropsController = new CropsController(mockCropRepo.Object);

            IActionResult result = cropsController.ListAllCrops();

            ViewResult viewResult = Assert.IsType<ViewResult>(result);

            List<Crop> viewResultModel = viewResult.Model as List<Crop>;

            Assert.Equal(viewResultModel.Count, mockCropList.Count);

            // Assert.Equal("Apple",viewResultModel.Find(m => m.CropID == 1).CropName);

            Assert.StrictEqual<List<Crop>>(mockCropList, viewResultModel);

            // Count the numbers of rows (actual)
            // Expected number of rows (3)
            // Assert.Equal(expectedNumberOfRows, actualNumberOfRow);

        }

        public void ShouldReturnViewForSearchCrops()
        {
            Mock<ICropRepo> mockCropRepo = new Mock<ICropRepo>();
            List<Crop> mockCropList = PopulateCrops();

            int? classficationID = 2;

            mockCropRepo.Setup(m => m.SearchCrops(It.IsAny<Int32?>())).Returns(mockCropList.FindAll(c => c.ClassificationID == classficationID));

            CropsController cropsController = new CropsController(mockCropRepo.Object);

            IActionResult result = cropsController.SearchCrops(classficationID);

            ViewResult viewResult = Assert.IsType<ViewResult>(result);

            List<Crop> viewResultModel = viewResult.Model as List<Crop>;
        }

        private List<Crop> PopulateCrops()
        {
            List<Crop> cropList = new List<Crop>();

            Crop crop = new Crop
            {
                CropID = 1,
                CropName = "Apple",
                CropVariety = null,
                ClassificationID = 1
            };
            cropList.Add(crop);

            crop = new Crop
            {
                CropID = 2,
                CropName = "Bok Choi",
                CropVariety = null,
                ClassificationID = 2
            };
            cropList.Add(crop);

            crop = new Crop
            {
                CropID = 1,
                CropName = "Basil",
                CropVariety = null,
                ClassificationID = 3
            };
            cropList.Add(crop);

            crop = new Crop
            {
                CropID = 4,
                CropName = "Beans",
                CropVariety = "Green",
                ClassificationID = 2
            };
            cropList.Add(crop);

            return cropList;
        }
    }
}
