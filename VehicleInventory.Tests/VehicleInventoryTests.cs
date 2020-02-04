using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CodingExercise.Data.Models;
using VehicleInventory.Services;
using System.Linq;
using System;

namespace VehicleInventory.Tests
{
    [TestClass]
    public class VehicleInventoryTests : TestsBase
    {
        private List<VehicleInStock> _vehicleInStocks
        {
            get
            {
                var dummyData = new List<VehicleInStock>()
            {
                new VehicleInStock()
                {
                    DateBought = DateTime.Now,
                    PriceBought = 10,
                    Model = new VehicleModel
                    {
                        Year = 1988,
                        Name = "80 B3",
                        Id = 1,

                        Make = new VehicleMake
                        {
                            Name = "Audi"
                        }
                    }
                }
            };

                return dummyData;
            }
        }

        [TestMethod]
        public void GetAllVehiclesInStockFlatTest()
        {
            var dummyData = _vehicleInStocks;

            ///set up mocked context
            ///insert records 
            ///apply and assert method
            context.VehiclesInStock = GetMockDbSet(dummyData).Object;

            var service = new VehicleInventoryService(context, Mapper);

            var mapperTest = service.GetAllVehiclesInStockFlat();

            var data = dummyData.First();
            var flatData = mapperTest.First();

            Assert.AreEqual(flatData.Make, data.Model.Make.Name);
            Assert.AreEqual(flatData.Model, data.Model.Name);
            Assert.AreEqual(flatData.Year, data.Model.Year);
            Assert.AreEqual(flatData.DateBought, data.DateBought);
            Assert.AreEqual(flatData.DateSold, data.DateSold);
            Assert.AreEqual(flatData.PriceSold, data.PriceSold);
            Assert.AreEqual(flatData.PriceBought, data.PriceBought);
        }

        [TestMethod]
        public void GetVehiclesInStockByIdTest()
        {
            var dummyData = _vehicleInStocks;

            context.VehiclesInStock = GetMockDbSet(dummyData).Object;

            var service = new VehicleInventoryService(context, Mapper);

            var dtoResult = service.GetVehicleInStockByIdFlat(1);

            var data = dummyData.First();
            var flatData = dtoResult;

            Assert.AreEqual(flatData.Make, data.Model.Make.Name);
            Assert.AreEqual(flatData.Model, data.Model.Name);
            Assert.AreEqual(flatData.Year, data.Model.Year);
            Assert.AreEqual(flatData.DateBought, data.DateBought);
            Assert.AreEqual(flatData.DateSold, data.DateSold);
            Assert.AreEqual(flatData.PriceSold, data.PriceSold);
            Assert.AreEqual(flatData.PriceBought, data.PriceBought);
        }

        [TestMethod]
        public void DeleteVehicleInStock()
        {
            var dummyData = _vehicleInStocks;


            context.VehiclesInStock = GetMockDbSet(dummyData).Object;

            var service = new VehicleInventoryService(context, Mapper);

            service.RemoveVehicleInStock(dummyData.First().Id);

            Assert.IsTrue(context.VehiclesInStock.First(vs => vs.Id == dummyData.First().Id).IsDeleted);

        }
    
        [TestMethod]
        public void GetVehicleByIdNotFoundTest()
        {
            var dummyData = _vehicleInStocks;
            var dummyId = 99999;

            context.VehiclesInStock = GetMockDbSet(dummyData).Object;

            var service = new VehicleInventoryService(context, Mapper);

            var dtoResult = service.GetVehicleInStockByIdFlat(dummyId);

            
            Assert.IsNull(dtoResult);
        }
    }
}
