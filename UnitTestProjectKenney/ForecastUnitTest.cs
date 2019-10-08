using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCWebAppKenney.Controllers;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.ApplicationUserModel;
using MVCWebAppKenney.Models.CropModel;
using MVCWebAppKenney.Models.CropYieldModel;
using MVCWebAppKenney.Models.FarmModel;
using MVCWebAppKenney.Models.ForecastModel;
using MVCWebAppKenney.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProjectKenney
{
    public class ForecastUnitTest
    {
        private Mock<IForecastRepo> mockForecastRepo;
        private Mock<IApplicationUserRepo> mockUserRepo;
        private Mock<ICropRepo> mockCropRepo;
        private AnalystController analystController;

        public ForecastUnitTest()
        {
            mockForecastRepo = new Mock<IForecastRepo>();
            mockCropRepo = new Mock<ICropRepo>();
            mockUserRepo = new Mock<IApplicationUserRepo>();
            analystController = new AnalystController(mockUserRepo.Object, mockForecastRepo.Object, mockCropRepo.Object);
        }

        [Fact]
        public void ShouldSearchForecasts()
        {
            IQueryable<Forecast> mockForecastList = PopulateForecasts();

            mockForecastRepo.Setup(m => m.ForecastList).Returns(mockForecastList);

            SearchForecastsViewModel model = new SearchForecastsViewModel();
            SearchForecastsViewModel result = analystController.SearchForecastsHelper(model);

            Assert.Equal(11, result.ForecastList.Count);
            Assert.Equal(mockForecastList.ToList<Forecast>(), model.ForecastList);
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

            return forecastList.AsQueryable<Forecast>();
        }
    }
}
