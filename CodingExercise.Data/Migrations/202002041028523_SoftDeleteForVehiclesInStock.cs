namespace CodingExercise.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDeleteForVehiclesInStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleInStocks", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleInStocks", "IsDeleted");
        }
    }
}
