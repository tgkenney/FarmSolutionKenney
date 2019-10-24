using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCWebAppKenney.Controllers;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.Analyst;
using MVCWebAppKenney.Models.ApplicationUserModel;
using MVCWebAppKenney.Models.CropModel;
using MVCWebAppKenney.Models.ForecastModel;
using MVCWebAppKenney.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace UnitTestProjectKenney
{
    public class ForecastUnitTest
    {
        private Mock<IForecastRepo> mockForecastRepo;
        private Mock<IApplicationUserRepo> mockUserRepo;
        private Mock<ICropRepo> mockCropRepo;
        private Mock<IAnalystRepo> mockAnalystRepo;
        private AnalystController analystController;

        public ForecastUnitTest()
        {
            mockForecastRepo = new Mock<IForecastRepo>();
            mockCropRepo = new Mock<ICropRepo>();
            mockUserRepo = new Mock<IApplicationUserRepo>();
            mockAnalystRepo = new Mock<IAnalystRepo>();
            analystController = new AnalystController(mockUserRepo.Object, mockForecastRepo.Object, mockCropRepo.Object, mockAnalystRepo.Object);
        }

        [Fact]
        public void ShouldSearchForecastsWithoutInputs()
        {
            // 1. Arrange
            IQueryable<Forecast> mockForecastList = PopulateForecasts();

            mockForecastRepo.Setup(m => m.ForecastList).Returns(mockForecastList);

            // 2. Act
            SearchForecastsViewModel model = new SearchForecastsViewModel();
            SearchForecastsViewModel result = analystController.SearchForecastsHelper(model);

            // 3. Assert
            Assert.Equal(11, result.ForecastList.Count);
            Assert.Equal(mockForecastList.ToList<Forecast>(), model.ForecastList);
        }

        [Fact]
        public void ShouldSearchForecastsWithAnalystInput()
        {
            // 1. Arrange
            IQueryable<Forecast> mockForecastList = PopulateForecasts();
            mockForecastRepo.Setup(m => m.ForecastList).Returns(mockForecastList);

            // 2. Act
            SearchForecastsViewModel model = new SearchForecastsViewModel();
            model.Id = "1";
            SearchForecastsViewModel result = analystController.SearchForecastsHelper(model);

            List<Forecast> expectedSearchResult = mockForecastList.Where(m => m.Id == "1").ToList<Forecast>();

            // 3. Assert
            Assert.Equal(5, result.ForecastList.Count);
            Assert.Equal(expectedSearchResult, model.ForecastList);
        }

        [Fact]
        public void ShouldSearchForecastsWithCropInput()
        {
            // 1. Arrange
            IQueryable<Forecast> mockForecastList = PopulateForecasts();
            mockForecastRepo.Setup(m => m.ForecastList).Returns(mockForecastList);

            // 2. Act
            SearchForecastsViewModel model = new SearchForecastsViewModel();
            model.CropID = 1;
            SearchForecastsViewModel result = analystController.SearchForecastsHelper(model);

            List<Forecast> expectedSearchResult = mockForecastList.Where(m => m.CropID == 1).ToList<Forecast>();

            // 3. Assert
            Assert.Equal(10, result.ForecastList.Count);
            Assert.Equal(expectedSearchResult, model.ForecastList);
        }

        public IQueryable<Forecast> PopulateForecasts()
        {
            List<Forecast> forecastList = new List<Forecast>();

            Forecast forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "1"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "1"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "1"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "1"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "1"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "2"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "2"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "2"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "2"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 1,
                Id = "2"
            };
            forecastList.Add(forecast);

            forecast = new Forecast
            {
                StartDate = new DateTime(2019, 2, 17),
                EndDate = new DateTime(2019, 2, 23),
                ForecastAmount = 85,
                ActualSales = 80,
                CropID = 2,
                Id = "2"
            };
            forecastList.Add(forecast);

            return forecastList.AsQueryable<Forecast>();
        }
    }
}
