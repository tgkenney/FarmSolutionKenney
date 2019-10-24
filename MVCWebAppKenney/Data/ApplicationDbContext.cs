using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCWebAppKenney.Models;
using MVCWebAppKenney.Models.Analyst;

namespace MVCWebAppKenney.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } // end constructor

        // Adds the table to the database
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<CanProduce> CanProduce { get; set; }
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CropYield> CropYields { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Analyst> Analysts { get; set; }
    } // end class
} // end namespace