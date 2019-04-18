using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MVCWebAppKenney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Data
{
    public class DbInitializer
    {
        // Instance or object method
        // Crop crop = new Crop();
        // crop.FindCrop();

        // Class or static method
        //Crop.FindCrop();

        public static void Initialize(IServiceProvider services)
        {
            // Database
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();

            // Users
            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            if (!database.ApplicationUsers.Any())
            {
                ApplicationUser applicationUser = new ApplicationUser("Test", "Analyst1", "TestAnalyst1@wvu.edu", "304-000-0001", "TestAnalyst1");
                database.ApplicationUsers.Add(applicationUser);


                database.SaveChanges();
            }
            // Classifications
            if (!database.Classifications.Any())
            {
                Classification classification = new Classification
                {
                    ClassificationName = "Fruit"
                };
                database.Classifications.Add(classification);

                classification = new Classification
                {
                    ClassificationName = "Vegetable"
                };
                database.Classifications.Add(classification);

                classification = new Classification
                {
                    ClassificationName = "Herb"
                };
                database.Classifications.Add(classification);

                database.SaveChanges();
            }
            // Crops
            if (!database.Crops.Any())
            {
                Crop crop = new Crop
                {
                    CropName = "Apple",
                    CropVariety = null,
                    ClassificationID = 1
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Bok Choi",
                    CropVariety = null,
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Basil",
                    CropVariety = null,
                    ClassificationID = 3
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Beans",
                    CropVariety = "Green",
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Beans",
                    CropVariety = "Roma",
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Beets",
                    CropVariety = null,
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Berries",
                    CropVariety = "Mixed",
                    ClassificationID = 1
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "BlueBerries",
                    CropVariety = null,
                    ClassificationID = 1
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Broccoli",
                    CropVariety = null,
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Brussel sprouts",
                    CropVariety = null,
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Cabbage",
                    CropVariety = "Green",
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Cabbage",
                    CropVariety = "Red",
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Carrot",
                    CropVariety = null,
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Cauliflower",
                    CropVariety = null,
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Celeriac",
                    CropVariety = null,
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Celery",
                    CropVariety = null,
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Chard",
                    CropVariety = null,
                    ClassificationID = 2
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Cilantro",
                    CropVariety = null,
                    ClassificationID = 3
                };
                database.Crops.Add(crop);

                crop = new Crop
                {
                    CropName = "Collards",
                    CropVariety = null,
                    ClassificationID = 2

                };
                database.Crops.Add(crop);

                database.SaveChanges();
            }
            // Farms
            if (!database.Farms.Any())
            {
                
                Farm farm = new Farm
                {
                    FarmName = "Grow OV",
                    FarmAddress = "1006 Grandview St, Wheeling, WV 26003",
                    FarmSize = 5500
                };
                database.Farms.Add(farm);

                farm = new Farm
                {
                    FarmName = "Bluebird",
                    FarmAddress = "190 Alamo Rd SE, Carrollton, OH 44615",
                    FarmSize = 3000
                };
                database.Farms.Add(farm);

                farm = new Farm
                {
                    FarmName = "Family Roots",
                    FarmAddress = "245 Hervey Ln, Wellsburg, WV 26070",
                    FarmSize = 1000
                };
                database.Farms.Add(farm);

                database.Farms.Add(farm);

                farm = new Farm
                {
                    FarmName = "Oak Hill",
                    FarmAddress = "37 Old Trails Rd. Avella, PA 15312",
                    FarmSize = 1500
                };
                database.Farms.Add(farm);
                
                database.SaveChanges();
            }
            // CanProduce
            if (!database.CanProduce.Any())
            {
                CanProduce produce = new CanProduce
                {
                    CropID = 1,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 17,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 16,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 15,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 11,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 18,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 10,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 8,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 6,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 5,
                    FarmID = 1
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 1,
                    FarmID = 2
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 17,
                    FarmID = 2
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 16,
                    FarmID = 2
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 15,
                    FarmID = 2
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 14,
                    FarmID = 2
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 15,
                    FarmID = 3
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 11,
                    FarmID = 3
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 18,
                    FarmID = 3
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 10,
                    FarmID = 3
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 8,
                    FarmID = 4
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 6,
                    FarmID = 4
                };
                database.CanProduce.Add(produce);

                produce = new CanProduce
                {
                    CropID = 5,
                    FarmID = 4
                };
                database.CanProduce.Add(produce);

                database.SaveChanges();
            }
            // Forecasts
            if (!database.Forecasts.Any())
            {

                Forecast forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 2, 17),
                    EndDate = new DateTime(2019, 2, 23),
                    ForecastAmount = 85,
                    ActualSales = 80,
                    CropID = 1
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 2, 24),
                    EndDate = new DateTime(2019, 3, 2),
                    ForecastAmount = 100,
                    ActualSales = 90,
                    CropID = 1
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 3, 3),
                    EndDate = new DateTime(2019, 3, 9),
                    ForecastAmount = 120,
                    ActualSales = null,
                    CropID = 1
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 2, 17),
                    EndDate = new DateTime(2019, 2, 23),
                    ForecastAmount = 15,
                    ActualSales = 15,
                    CropID = 17
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 2, 24),
                    EndDate = new DateTime(2019, 3, 2),
                    ForecastAmount = 20,
                    ActualSales = 20,
                    CropID = 17
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 3, 3),
                    EndDate = new DateTime(2019, 3, 9),
                    ForecastAmount = 25,
                    ActualSales = null,
                    CropID = 17
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 2, 17),
                    EndDate = new DateTime(2019, 2, 23),
                    ForecastAmount = 3,
                    ActualSales = 2,
                    CropID = 16
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 2, 24),
                    EndDate = new DateTime(2019, 3, 2),
                    ForecastAmount = 4,
                    ActualSales = 3,
                    CropID = 16
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 3, 3),
                    EndDate = new DateTime(2019, 3, 9),
                    ForecastAmount = 4,
                    ActualSales = null,
                    CropID = 16
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 2, 17),
                    EndDate = new DateTime(2019, 2, 23),
                    ForecastAmount = 4,
                    ActualSales = 5,
                    CropID = 13
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 2, 24),
                    EndDate = new DateTime(2019, 3, 2),
                    ForecastAmount = 4,
                    ActualSales = 3,
                    CropID = 13
                };
                database.Forecasts.Add(forecast);

                forecast = new Forecast
                {
                    StartDate = new DateTime(2019, 3, 3),
                    EndDate = new DateTime(2019, 3, 9),
                    ForecastAmount = 4,
                    ActualSales = null,
                    CropID = 13
                };
                database.Forecasts.Add(forecast);

                database.SaveChanges();
            }
        }
    }
}
