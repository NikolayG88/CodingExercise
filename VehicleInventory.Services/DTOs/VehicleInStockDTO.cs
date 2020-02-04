using System;

namespace VehicleInventory.Services.DTOs
{
    public class VehicleInStockDTO
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public decimal PriceBought { get; set; }

        public decimal PriceSold { get; set; }

        public DateTime? DateSold { get; set; }

        public DateTime DateBought { get; set; }
    }
}
