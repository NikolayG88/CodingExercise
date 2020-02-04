namespace CodingExercise.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakeId = c.Int(nullable: false),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleMakes", t => t.MakeId, cascadeDelete: true)
                .Index(t => t.MakeId);
            
            CreateTable(
                "dbo.VehicleInStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriceBought = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSold = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateBought = c.DateTime(nullable: false),
                        DateSold = c.DateTime(nullable: false),
                        Model_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleModels", t => t.Model_Id, cascadeDelete: true)
                .Index(t => t.Model_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "MakeId", "dbo.VehicleMakes");
            DropForeignKey("dbo.VehicleInStocks", "Model_Id", "dbo.VehicleModels");
            DropIndex("dbo.VehicleInStocks", new[] { "Model_Id" });
            DropIndex("dbo.VehicleModels", new[] { "MakeId" });
            DropTable("dbo.VehicleInStocks");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleMakes");
        }
    }
}
