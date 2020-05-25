using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MoscowWiFi.WebService.DomainObjects;

namespace MoscowWiFi.WebService.ApplicationServices.Ports.Gateways.Database
{
    public class MoscowWiFiContext : DbContext
    {
        public DbSet<AccessPoint> AccessPoints { get; set; }

        public MoscowWiFiContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessPoint>().HasData(
                new List<AccessPoint>
                {
                    new AccessPoint()
                    {
                        District = "123",
                        Location = "123",
                        Password = "123",
                        Name = "123",
                        AccessFlag = "asda",
                        AdmArea = "asdasd",
                        CoverageArea = 400,
                        FunctionFlag = "asdasd",
                        WiFiName = "asda",
                        NumberOfAccessPoints = 2,
                        Id = 1
                    },
                    new AccessPoint()
                    {
                        District = "123",
                        Location = "123",
                        Password = "123",
                        Name = "123",
                        AccessFlag = "asda",
                        AdmArea = "asdasd",
                        CoverageArea = 400,
                        FunctionFlag = "asdasd",
                        WiFiName = "asda",
                        NumberOfAccessPoints = 3,
                        Id = 2
                    },
                }
            );
        }
    }
}