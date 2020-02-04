using CodingExercise.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Data
{
    public interface IVehicleInventoryContext
    {
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }
        DbSet<VehicleInStock> VehiclesInStock { get; set; }

    }
}
