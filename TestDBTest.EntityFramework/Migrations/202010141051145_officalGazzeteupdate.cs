namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class officalGazzeteupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ManufacturerInfoes", "StartDateOfFillForm", c => c.DateTime(nullable: false));
            AddColumn("dbo.ManufacturerInfoes", "EndDateOfFillForm", c => c.DateTime(nullable: false));
            AddColumn("dbo.ManufacturerInfoes", "SourceOfApplication", c => c.Int(nullable: false));
            AddColumn("dbo.ManufacturerInfoes", "TypeOfApp", c => c.Int(nullable: false));
            AddColumn("dbo.MedicalDeviceInfoes", "DidReactionGoneAfterUseMedicalDevice", c => c.Int(nullable: false));
            AddColumn("dbo.MedicalDeviceInfoes", "DoesTheReactionOccurAgain", c => c.Int(nullable: false));
            AddColumn("dbo.People", "OutComeOfAverseReaction", c => c.Int(nullable: false));
            AddColumn("dbo.People", "ConnectionBetweenAdverseReaction", c => c.Int(nullable: false));
            DropColumn("dbo.ManufacturerInfoes", "DateOfFillForm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ManufacturerInfoes", "DateOfFillForm", c => c.DateTime(nullable: false));
            DropColumn("dbo.People", "ConnectionBetweenAdverseReaction");
            DropColumn("dbo.People", "OutComeOfAverseReaction");
            DropColumn("dbo.MedicalDeviceInfoes", "DoesTheReactionOccurAgain");
            DropColumn("dbo.MedicalDeviceInfoes", "DidReactionGoneAfterUseMedicalDevice");
            DropColumn("dbo.ManufacturerInfoes", "TypeOfApp");
            DropColumn("dbo.ManufacturerInfoes", "SourceOfApplication");
            DropColumn("dbo.ManufacturerInfoes", "EndDateOfFillForm");
            DropColumn("dbo.ManufacturerInfoes", "StartDateOfFillForm");
        }
    }
}
