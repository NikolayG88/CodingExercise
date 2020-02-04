using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Data.Models
{
    public class VehicleInStock : IDeletable
    {
        public int Id { get; set; }
        public int ModelId { get; set; }


        public decimal PriceBought { get; set; }
        public decimal PriceSold { get; set; }

        public DateTime DateBought { get; set; }
        public DateTime? DateSold { get; set; }
        public virtual VehicleModel Model { get; set; }

        public bool IsDeleted { get; set; }
    }
}
