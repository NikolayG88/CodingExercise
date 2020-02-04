using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Services.DTOs
{
    public class AddVehicleInStockDTO
    {
        public int ModelId { get; set; }

        public DateTime DateBought{ get; set; }

        public decimal PriceBought { get; set; }
    }
}
