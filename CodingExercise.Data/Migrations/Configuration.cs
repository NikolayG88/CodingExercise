namespace CodingExercise.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using CodingExercise.Data.Models;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<CodingExercise.Data.VehicleInventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodingExercise.Data.VehicleInventoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //if (!System.Diagnostics.Debugger.IsAttached)
            //    System.Diagnostics.Debugger.Launch();
#if (DEBUG)
            SeedSampleData(context);
            SeedTestUsers(context);
#endif
        }

        private void SeedSampleData(VehicleInventoryContext context)
        {
            if (context.VehiclesInStock.Any())
            {
                return;
            }

            var audi = new VehicleMake { Name = "Audi" };
            var dodge = new VehicleMake { Name = "Dodge" };
            var fiat = new VehicleMake { Name = "Fiat" };

            var audi80b3 = new VehicleModel
            {
                Year = 1988,
                Name = "80 B3",
                Make = audi
            };
            var challengerSXT = new VehicleModel
            {
                Year = 2014,
                Name = "Challenger SXT",

                Make = dodge
            };
            var challengerRT = new VehicleModel
            {
                Year = 2014,
                Name = "Challenger R/T",
                Make = dodge
            };
            var fiatPop = new VehicleModel
            {
                Year = 2014,
                Name = "POP",

                Make = fiat
            };

            var dummyVehicles = new List<VehicleInStock>()
            {
                new VehicleInStock()
                {
                    DateBought = DateTime.Now,
                    PriceBought = 10,
                    Model = audi80b3
                },
                new VehicleInStock()
                {
                    DateBought = DateTime.Now,
                    PriceBought = 30000,
                    Model = challengerRT
                },
                new VehicleInStock()
                {
                    DateBought = DateTime.Now,
                    PriceBought = 20000,
                    Model = challengerSXT
                },
                new VehicleInStock()
                {
                    DateBought = DateTime.Now,
                    PriceBought = 13000,
                    Model = fiatPop
                }
            };

            context.VehiclesInStock.AddRange(dummyVehicles);
            context.SaveChanges();

        }

        private void SeedTestUsers(VehicleInventoryContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var hasher = new PasswordHasher();

            context.Users.AddOrUpdate(new User
            {
                UserName = "Test",
                Email = "Test@mail.com",
                PasswordHash = hasher.HashPassword("Test1!"),
                SecurityStamp = Guid.NewGuid().ToString()
            });


            context.SaveChanges();
        }
    }
}
