namespace CodingExercise.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertyToVehicleInStock : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VehicleInStocks", name: "Model_Id", newName: "ModelId");
            RenameIndex(table: "dbo.VehicleInStocks", name: "IX_Model_Id", newName: "IX_ModelId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.VehicleInStocks", name: "IX_ModelId", newName: "IX_Model_Id");
            RenameColumn(table: "dbo.VehicleInStocks", name: "ModelId", newName: "Model_Id");
        }
    }
}
