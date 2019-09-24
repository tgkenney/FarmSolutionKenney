using Moq;
using MVCWebAppKenney.Controllers;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.CropModel;
using MVCWebAppKenney.Models.CropYieldModel;
using MVCWebAppKenney.Models.FarmModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTestProjectKenney
{
    public class CropYieldUnitTest
    {
        [Fact]
        public void ShouldSearchCropYields()
        {
            // 1. Arrange
            Mock<ICropYieldRepo> mockCropYieldRepo = new Mock<ICropYieldRepo>();
            Mock<ICropRepo> mockCropRepo = new Mock<ICropRepo>();
            Mock<IFarmRepo> mockFarmRepo = new Mock<IFarmRepo>();
            CropsController cropsController = new CropsController(mockCropYieldRepo.Object, mockCropRepo.Object, mockFarmRepo.Object);

            // Populate the Mock CropYield Objects
            IQueryable<CropYield> mockCropYieldList = PopulateCropYields();

            // 2. Act

            // 3. Assert

        }

        public List<CropYield> PopulateCropYields()
        {
            List<CropYield> cropYields = new List<CropYield>();


            return cropYields;
        }
    }
}
