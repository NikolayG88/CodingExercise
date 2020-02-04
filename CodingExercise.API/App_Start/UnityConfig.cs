using VehicleInventory.Services.Contracts;
using CodingExercise.API.App_Start;
using VehicleInventory.Services;
using CodingExercise.Data;
using System.Web.Http;
using Unity.WebApi;
using Unity;

namespace CodingExercise.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);


            var mapperConfig = new MapperConfig();

            container.RegisterInstance(mapperConfig.CreateMapper());

            container.RegisterType<IVehicleInventoryService, VehicleInventoryService>();
            container.RegisterType<IVehicleInventoryContext, VehicleInventoryContext>();
        }
    }
}