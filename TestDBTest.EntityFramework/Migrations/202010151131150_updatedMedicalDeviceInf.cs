namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMedicalDeviceInf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalDeviceInfoes", "StartDateFillForm", c => c.DateTime());
            AddColumn("dbo.MedicalDeviceInfoes", "EndDateFillForm", c => c.DateTime());
            DropColumn("dbo.ManufacturerInfoes", "StartDateOfFillForm");
            DropColumn("dbo.ManufacturerInfoes", "EndDateOfFillForm");
            DropColumn("dbo.MedicalDeviceInfoes", "DateOfUseMedicalDevice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicalDeviceInfoes", "DateOfUseMedicalDevice", c => c.DateTime());
            AddColumn("dbo.ManufacturerInfoes", "EndDateOfFillForm", c => c.DateTime(nullable: false));
            AddColumn("dbo.ManufacturerInfoes", "StartDateOfFillForm", c => c.DateTime(nullable: false));
            DropColumn("dbo.MedicalDeviceInfoes", "EndDateFillForm");
            DropColumn("dbo.MedicalDeviceInfoes", "StartDateFillForm");
        }
    }
}
