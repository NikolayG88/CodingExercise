using CodingExercise.Data;
using System.Data.Entity;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Linq;
using CodingExercise.API.App_Start;

namespace VehicleInventory.Tests
{
    public class TestsBase
    {

        protected IMapper Mapper
        {
            get
            {
                var mapperConfig = new MapperConfig();

                return mapperConfig.CreateMapper();
            }
        }

        private VehicleInventoryContext _context { get; set; }
        protected VehicleInventoryContext context
        {
            get
            {
                if(_context != null)
                {
                    return _context;
                }

                _context = new VehicleInventoryContext();

                return _context;
            }
        }

        protected Mock<DbSet<T>> GetMockDbSet<T>(List<T> dataSet) where T : class
        {
            var queryable = dataSet.AsQueryable();

            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mockSet;
        }
    }
}
