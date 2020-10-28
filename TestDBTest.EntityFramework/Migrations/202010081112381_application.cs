namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class application : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NearMisses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescriptionNearMiss = c.String(),
                        NameAndForm = c.String(),
                        Strength = c.Int(nullable: false),
                        PathOfAdministration = c.String(),
                        Indication = c.String(),
                        Doctor = c.Boolean(nullable: false),
                        Pharmacist = c.Boolean(nullable: false),
                        Nurse = c.Boolean(nullable: false),
                        Other1 = c.Boolean(nullable: false),
                        RewritingTherapy = c.Boolean(nullable: false),
                        PrescribingTherapy = c.Boolean(nullable: false),
                        PreparingTherapy = c.Boolean(nullable: false),
                        AdministrationApplication = c.Boolean(nullable: false),
                        Other2 = c.Boolean(nullable: false),
                        CorrectiveMeasureTaken = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlaceOfErrorDetections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntesiveCare = c.Boolean(nullable: false),
                        SemiIntesiveCare = c.Boolean(nullable: false),
                        DayHospital = c.Boolean(nullable: false),
                        OperacionRoom = c.Boolean(nullable: false),
                        PharmaceuticalDepartment = c.Boolean(nullable: false),
                        Other = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfApplications",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NearMissId = c.Int(),
                        PersonId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NearMisses", t => t.NearMissId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.NearMissId)
                .Index(t => t.PersonId);
            
            AddColumn("dbo.People", "LastName", c => c.String());
            AddColumn("dbo.People", "Male", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "Female", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "ErrorDetectionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "ErrorDetectionTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.People", "PlaceOfErrorDetectionId", c => c.Int());
            CreateIndex("dbo.People", "PlaceOfErrorDetectionId");
            AddForeignKey("dbo.People", "PlaceOfErrorDetectionId", "dbo.PlaceOfErrorDetections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypeOfApplications", "PersonId", "dbo.People");
            DropForeignKey("dbo.TypeOfApplications", "NearMissId", "dbo.NearMisses");
            DropForeignKey("dbo.People", "PlaceOfErrorDetectionId", "dbo.PlaceOfErrorDetections");
            DropIndex("dbo.TypeOfApplications", new[] { "PersonId" });
            DropIndex("dbo.TypeOfApplications", new[] { "NearMissId" });
            DropIndex("dbo.People", new[] { "PlaceOfErrorDetectionId" });
            DropColumn("dbo.People", "PlaceOfErrorDetectionId");
            DropColumn("dbo.People", "ErrorDetectionTime");
            DropColumn("dbo.People", "ErrorDetectionDate");
            DropColumn("dbo.People", "DateOfBirth");
            DropColumn("dbo.People", "Female");
            DropColumn("dbo.People", "Male");
            DropColumn("dbo.People", "LastName");
            DropTable("dbo.TypeOfApplications");
            DropTable("dbo.PlaceOfErrorDetections");
            DropTable("dbo.NearMisses");
        }
    }
}
