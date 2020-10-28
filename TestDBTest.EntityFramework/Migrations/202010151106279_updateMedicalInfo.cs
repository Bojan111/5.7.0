namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMedicalInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicalDeviceInfoes", "DateOfUseMedicalDevice", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicalDeviceInfoes", "DateOfUseMedicalDevice", c => c.DateTime(nullable: false));
        }
    }
}
