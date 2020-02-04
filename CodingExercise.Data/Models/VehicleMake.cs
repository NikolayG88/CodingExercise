using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Data.Models
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<VehicleModel> Models { get; set; }
    }
}
