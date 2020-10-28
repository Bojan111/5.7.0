namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedGazette : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfficialGazzetes", "ManufacturerInfoId", "dbo.ManufacturerInfoes");
            DropForeignKey("dbo.OfficialGazzetes", "MedicalDeviceInfoId", "dbo.MedicalDeviceInfoes");
            DropForeignKey("dbo.OfficialGazzetes", "UseOfMedicalDevicesId", "dbo.UseOfMedicalDevices");
            DropIndex("dbo.OfficialGazzetes", new[] { "MedicalDeviceInfoId" });
            DropIndex("dbo.OfficialGazzetes", new[] { "UseOfMedicalDevicesId" });
            DropIndex("dbo.OfficialGazzetes", new[] { "ManufacturerInfoId" });
            AddColumn("dbo.ManufacturerInfoes", "OfficialGazzeteId", c => c.Int(nullable: false));
            AddColumn("dbo.MedicalDeviceInfoes", "OfficialGazzeteId", c => c.Int(nullable: false));
            AddColumn("dbo.OfficialGazzetes", "DescribeYourAdverseReaction", c => c.String());
            AddColumn("dbo.OfficialGazzetes", "OutComeOfAverseReaction", c => c.Int(nullable: false));
            AddColumn("dbo.OfficialGazzetes", "ErrorDetectionDate", c => c.DateTime());
            AddColumn("dbo.OfficialGazzetes", "ConnectionBetweenAdverseReaction", c => c.Int(nullable: false));
            AddColumn("dbo.UseOfMedicalDevices", "OfficialGazzeteId", c => c.Int(nullable: false));
            CreateIndex("dbo.ManufacturerInfoes", "OfficialGazzeteId");
            CreateIndex("dbo.MedicalDeviceInfoes", "OfficialGazzeteId");
            CreateIndex("dbo.UseOfMedicalDevices", "OfficialGazzeteId");
            AddForeignKey("dbo.ManufacturerInfoes", "OfficialGazzeteId", "dbo.OfficialGazzetes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicalDeviceInfoes", "OfficialGazzeteId", "dbo.OfficialGazzetes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UseOfMedicalDevices", "OfficialGazzeteId", "dbo.OfficialGazzetes", "Id", cascadeDelete: true);
            DropColumn("dbo.OfficialGazzetes", "MedicalDeviceInfoId");
            DropColumn("dbo.OfficialGazzetes", "UseOfMedicalDevicesId");
            DropColumn("dbo.OfficialGazzetes", "ManufacturerInfoId");
            DropColumn("dbo.People", "ErrorDetectionDate");
            DropColumn("dbo.People", "DescribeYourAdverseReaction");
            DropColumn("dbo.People", "OutComeOfAverseReaction");
            DropColumn("dbo.People", "ConnectionBetweenAdverseReaction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "ConnectionBetweenAdverseReaction", c => c.Int(nullable: false));
            AddColumn("dbo.People", "OutComeOfAverseReaction", c => c.Int(nullable: false));
            AddColumn("dbo.People", "DescribeYourAdverseReaction", c => c.String());
            AddColumn("dbo.People", "ErrorDetectionDate", c => c.DateTime());
            AddColumn("dbo.OfficialGazzetes", "ManufacturerInfoId", c => c.Int(nullable: false));
            AddColumn("dbo.OfficialGazzetes", "UseOfMedicalDevicesId", c => c.Int(nullable: false));
            AddColumn("dbo.OfficialGazzetes", "MedicalDeviceInfoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UseOfMedicalDevices", "OfficialGazzeteId", "dbo.OfficialGazzetes");
            DropForeignKey("dbo.MedicalDeviceInfoes", "OfficialGazzeteId", "dbo.OfficialGazzetes");
            DropForeignKey("dbo.ManufacturerInfoes", "OfficialGazzeteId", "dbo.OfficialGazzetes");
            DropIndex("dbo.UseOfMedicalDevices", new[] { "OfficialGazzeteId" });
            DropIndex("dbo.MedicalDeviceInfoes", new[] { "OfficialGazzeteId" });
            DropIndex("dbo.ManufacturerInfoes", new[] { "OfficialGazzeteId" });
            DropColumn("dbo.UseOfMedicalDevices", "OfficialGazzeteId");
            DropColumn("dbo.OfficialGazzetes", "ConnectionBetweenAdverseReaction");
            DropColumn("dbo.OfficialGazzetes", "ErrorDetectionDate");
            DropColumn("dbo.OfficialGazzetes", "OutComeOfAverseReaction");
            DropColumn("dbo.OfficialGazzetes", "DescribeYourAdverseReaction");
            DropColumn("dbo.MedicalDeviceInfoes", "OfficialGazzeteId");
            DropColumn("dbo.ManufacturerInfoes", "OfficialGazzeteId");
            CreateIndex("dbo.OfficialGazzetes", "ManufacturerInfoId");
            CreateIndex("dbo.OfficialGazzetes", "UseOfMedicalDevicesId");
            CreateIndex("dbo.OfficialGazzetes", "MedicalDeviceInfoId");
            AddForeignKey("dbo.OfficialGazzetes", "UseOfMedicalDevicesId", "dbo.UseOfMedicalDevices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OfficialGazzetes", "MedicalDeviceInfoId", "dbo.MedicalDeviceInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OfficialGazzetes", "ManufacturerInfoId", "dbo.ManufacturerInfoes", "Id", cascadeDelete: true);
        }
    }
}
