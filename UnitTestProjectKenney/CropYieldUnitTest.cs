using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCWebAppKenney.Controllers;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.CropModel;
using MVCWebAppKenney.Models.CropYieldModel;
using MVCWebAppKenney.Models.FarmModel;
using MVCWebAppKenney.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProjectKenney
{
    public class CropYieldUnitTest
    {
        private Mock<ICropYieldRepo> mockCropYieldRepo;
        private Mock<ICropRepo> mockCropRepo;
        private Mock<IFarmRepo> mockFarmRepo;
        private CropsController cropsController;

        public CropYieldUnitTest()
        {
            mockCropYieldRepo = new Mock<ICropYieldRepo>();
            mockCropRepo = new Mock<ICropRepo>();
            mockFarmRepo = new Mock<IFarmRepo>();
            cropsController = new CropsController(mockCropYieldRepo.Object, mockCropRepo.Object, mockFarmRepo.Object);
        }

        [Fact]
        public void ShouldSearchCropYieldsWithoutInputs()
        {
            // 1. Arrange

            // Populate the Mock CropYield Objects
            IQueryable<CropYield> mockCropYieldList = PopulateCropYields();

            mockCropYieldRepo.Setup(m => m.CropYieldList).Returns(mockCropYieldList);

            // 2. Act
            SearchCropYieldsViewModel model = new SearchCropYieldsViewModel();
            SearchCropYieldsViewModel result = cropsController.SearchCropYieldsHelper(model, 0);

            // 3. Assert
            Assert.Equal(4, result.CropYieldList.Count);
            Assert.Equal(mockCropYieldList.ToList<CropYield>(), model.CropYieldList);
        }

        [Fact]
        public void ShouldSearchCropYieldsWithCropInput()
        {
            // 1. Arrange

            // Populate the Mock CropYield Objects
            IQueryable<CropYield> mockCropYieldList = PopulateCropYields();

            mockCropYieldRepo.Setup(m => m.CropYieldList).Returns(mockCropYieldList);

            // 2. Act
            SearchCropYieldsViewModel model = new SearchCropYieldsViewModel();
            model.CropID = 1;
            SearchCropYieldsViewModel result = cropsController.SearchCropYieldsHelper(model, 0);

            List<CropYield> expectedSearchResult = mockCropYieldList.Where(m => m.CropID == 1).ToList<CropYield>();

            // 3. Assert
            Assert.Equal(2, result.CropYieldList.Count);
            Assert.Equal(expectedSearchResult, model.CropYieldList);
        }

        [Fact]
        public void ShouldSearchCropYieldsWithFarmInput()
        {
            // 1. Arrange

            // Populate the Mock CropYield Objects
            IQueryable<CropYield> mockCropYieldList = PopulateCropYields();

            mockCropYieldRepo.Setup(m => m.CropYieldList).Returns(mockCropYieldList);

            // 2. Act
            SearchCropYieldsViewModel model = new SearchCropYieldsViewModel();
            model.FarmID = 1;
            SearchCropYieldsViewModel result = cropsController.SearchCropYieldsHelper(model, 0);

            List<CropYield> expectedSearchResult = mockCropYieldList.Where(m => m.FarmID == 1).ToList<CropYield>();

            // 3. Assert
            Assert.Equal(2, result.CropYieldList.Count);
            Assert.Equal(expectedSearchResult, model.CropYieldList);
        }

        [Fact]
        public void ShouldSearchCropYieldsWithYearInput()
        {
            // 1. Arrange

            // Populate the Mock CropYield Objects
            IQueryable<CropYield> mockCropYieldList = PopulateCropYields();

            mockCropYieldRepo.Setup(m => m.CropYieldList).Returns(mockCropYieldList);

            // 2. Act
            SearchCropYieldsViewModel model = new SearchCropYieldsViewModel();
            model.SearchProductionYear = 2019;
            SearchCropYieldsViewModel result = cropsController.SearchCropYieldsHelper(model, 0);

            List<CropYield> expectedSearchResult = mockCropYieldList.Where(m => m.ProductionYear == 2019).ToList<CropYield>();

            // 3. Assert
            Assert.Equal(3, result.CropYieldList.Count);
            Assert.Equal(expectedSearchResult, model.CropYieldList);
        }

        [Fact]
        public void ShouldAddNewCropYield()
        {
            // 1. Arrange

            CropYield expectedCropYield = new CropYield
            {
                CropYieldID = 5,
                ProductionAmount = 400,
                ProductionYear = 2019,
                CropID = 1,
                FarmID = 1
            };

            CropYield addedCropYield = null;

            mockCropYieldRepo.Setup(m => m.AddCropYield(It.IsAny<CropYield>())).Returns(Task.CompletedTask).Callback<CropYield>(m => addedCropYield = m);

            // 2. Act

            var actualAddedCrop = cropsController.AddCropYieldHelper(expectedCropYield);

            // 3. Assert
            Assert.Equal(expectedCropYield.CropYieldID, addedCropYield.CropYieldID);
            Assert.Equal(expectedCropYield, addedCropYield);
        }

        [Fact]
        public async Task ShouldDeleteCropYield()
        {
            // 1. Arrange
            
            mockCropYieldRepo.Setup(repo => repo.DeleteCropYield(It.IsAny<Nullable<Int32>>())).Returns(Task.CompletedTask);
            int? cropYieldID = 1;

            // 2. Act
            
            await cropsController.DeleteCropYieldHelper(cropYieldID);

            // 3. Assert
            mockCropYieldRepo.Verify(m => m.DeleteCropYield(It.IsAny<Nullable<Int32>>()), Times.Once);
        }

        public IQueryable<CropYield> PopulateCropYields()
        {
            List<CropYield> cropYieldsList = new List<CropYield>();

            CropYield cropYield = new CropYield
            {
                CropYieldID = 1,
                ProductionAmount = 400,
                ProductionYear = 2019,
                CropID = 1,
                FarmID = 1
            };
            cropYieldsList.Add(cropYield);

            cropYield = new CropYield
            {
                CropYieldID = 2,
                ProductionAmount = 500,
                ProductionYear = 2019,
                CropID = 2,
                FarmID = 2
            };
            cropYieldsList.Add(cropYield);

            cropYield = new CropYield
            {
                CropYieldID = 3,
                ProductionAmount = 500,
                ProductionYear = 2018,
                CropID = 3,
                FarmID = 1
            };
            cropYieldsList.Add(cropYield);

            cropYield = new CropYield
            {
                CropYieldID = 4,
                ProductionAmount = 500,
                ProductionYear = 2019,
                CropID = 1,
                FarmID = 2
            };
            cropYieldsList.Add(cropYield);

            return cropYieldsList.AsQueryable<CropYield>();
        }
    }
}
