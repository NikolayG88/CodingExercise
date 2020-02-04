namespace CodingExercise.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateSold : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleInStocks", "DateSold", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleInStocks", "DateSold", c => c.DateTime(nullable: false));
        }
    }
}
