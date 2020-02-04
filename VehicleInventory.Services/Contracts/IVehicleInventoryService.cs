using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Services.DTOs;

namespace VehicleInventory.Services.Contracts
{
    public interface IVehicleInventoryService
    {

        List<VehicleInStockDTO> GetAllVehiclesInStockFlat();

        VehicleInStockDTO GetVehicleInStockByIdFlat(int vehicleId);

        int AddVehicleInStock(AddVehicleInStockDTO vehicle);

        int RemoveVehicleInStock(int vehicleId);
    }
}
