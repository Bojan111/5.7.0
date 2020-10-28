namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gazetteUpdatedsecondtime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicalDeviceInfoes", "DateOfUseMedicalDevice", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicalDeviceInfoes", "DateOfUseMedicalDevice", c => c.DateTime());
        }
    }
}
