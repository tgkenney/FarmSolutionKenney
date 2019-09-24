using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCWebAppKenney.Controllers;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.CropModel;
using MVCWebAppKenney.Models.CropYieldModel;
using MVCWebAppKenney.Models.FarmModel;
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
            Mock<ICropYieldRepo> mockCropYieldRepo = new Mock<ICropYieldRepo>();
            Mock<ICropRepo> mockCropRepo = new Mock<ICropRepo>();
            Mock<IFarmRepo> mockFarmRepo = new Mock<IFarmRepo>();
            CropsController cropsController = new CropsController(mockCropYieldRepo.Object, mockCropRepo.Object, mockFarmRepo.Object);
            List<Crop> mockCropList = PopulateCrops();

            mockCropRepo.Setup(m => m.ListAllCrops()).Returns(mockCropList);


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
            Mock<ICropYieldRepo> mockCropYieldRepo = new Mock<ICropYieldRepo>();
            Mock<ICropRepo> mockCropRepo = new Mock<ICropRepo>();
            Mock<IFarmRepo> mockFarmRepo = new Mock<IFarmRepo>();
            
            List<Crop> mockCropList = PopulateCrops();

            int? classficationID = 2;

            mockCropRepo.Setup(m => m.SearchCrops(It.IsAny<Int32?>())).Returns(mockCropList.FindAll(c => c.ClassificationID == classficationID));

            // 2. Act
            CropsController cropsController = new CropsController(mockCropYieldRepo.Object, mockCropRepo.Object, mockFarmRepo.Object);

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
            Mock<ICropYieldRepo> mockCropYieldRepo = new Mock<ICropYieldRepo>();
            Mock<ICropRepo> mockCropRepo = new Mock<ICropRepo>();
            Mock<IFarmRepo> mockFarmRepo = new Mock<IFarmRepo>();
            

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
            CropsController cropsController = new CropsController(mockCropYieldRepo.Object, mockCropRepo.Object, mockFarmRepo.Object);

            var actualAddedCrop = cropsController.AddCrop(expectedCrop);

            // 3. Assert
            Assert.Equal(expectedCrop.CropName, addedCrop.CropName);
            Assert.Equal(expectedCrop, addedCrop);
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
