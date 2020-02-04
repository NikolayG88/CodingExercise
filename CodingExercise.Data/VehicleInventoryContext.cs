using CodingExercise.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;


namespace CodingExercise.Data
{
    public class VehicleInventoryContext: IdentityDbContext<User>, IVehicleInventoryContext
    {
        public VehicleInventoryContext() : base ("DefaultConnectionString")
        {

        }

        public virtual DbSet<VehicleMake> VehicleMakes { get; set; }

        public virtual DbSet<VehicleModel> VehicleModels { get; set; }

        public virtual DbSet<VehicleInStock> VehiclesInStock { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VehicleMake>()
                .HasKey(vm => vm.Id)
                .HasMany(vm => vm.Models)
                .WithRequired(vm => vm.Make)
                .HasForeignKey(vm => vm.MakeId);

            builder.Entity<VehicleModel>().HasKey(vm => vm.Id);

            builder.Entity<VehicleInStock>()
                .HasKey(vs => vs.Id)
                .HasRequired(vs => vs.Model)
                .WithMany(m => m.VehiclesInStock)
                .HasForeignKey(vs => vs.ModelId);
          
        }

        public static VehicleInventoryContext Create()
        {
            return new VehicleInventoryContext();
        }

        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}
    }
}
