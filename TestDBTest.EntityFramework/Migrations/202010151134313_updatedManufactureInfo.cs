namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedManufactureInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ManufacturerInfoes", "DateOfUseMedicalDevice", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ManufacturerInfoes", "DateOfUseMedicalDevice");
        }
    }
}
