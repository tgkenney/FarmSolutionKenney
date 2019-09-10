using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCWebAppKenney.Controllers;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.CropModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        [Fact]
        public void ShouldReturnViewForSearchCrops()
        {
            // Testing
            // 1. Arrange
            Mock<ICropRepo> mockCropRepo = new Mock<ICropRepo>();
            List<Crop> mockCropList = PopulateCrops();

            int? classficationID = 2;

            mockCropRepo.Setup(m => m.SearchCrops(It.IsAny<Int32?>())).Returns(mockCropList.FindAll(c => c.ClassificationID == classficationID));

            // 2. Act
            CropsController cropsController = new CropsController(mockCropRepo.Object);

            IActionResult result = cropsController.SearchCrops(classficationID);

            // 3. Assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);

            List<Crop> viewResultModel = viewResult.Model as List<Crop>;

            Assert.Equal(viewResultModel.Count, mockCropList.FindAll(m => m.ClassificationID == classficationID).Count);
            Assert.Equal<List<Crop>>(mockCropList.FindAll(m => m.ClassificationID == classficationID), viewResultModel);
        }

        [Fact]
        public void ShouldAddNewCrop()
        {
            // 1. Arrange
            Mock<ICropRepo> mockCropRepo = new Mock<ICropRepo>();

            Crop expectedCrop = new Crop
            {
                CropID = 1,
                CropName = "Apple",
                CropVariety = null,
                ClassificationID = 1
            };

            Crop addedCrop = null;

            mockCropRepo.Setup(m => m.AddCrop(It.IsAny<Crop>())).Returns(Task.CompletedTask).Callback<Crop>(m => addedCrop = m);

            // 2. Act
            CropsController cropsController = new CropsController(mockCropRepo.Object);

            var actualAddedCrop = cropsController.AddCrop(expectedCrop);

            // 3. Assert
            Assert.Equal(expectedCrop.CropName, addedCrop.CropName);
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
                CropID = 3,
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
