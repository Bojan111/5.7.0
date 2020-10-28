namespace TestDBTest.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class updatepersonnearmisstypeofappaddmederr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "PlaceOfErrorDetectionId", "dbo.PlaceOfErrorDetections");
            DropForeignKey("dbo.TypeOfApplications", "PersonId", "dbo.People");
            DropIndex("dbo.People", new[] { "PlaceOfErrorDetectionId" });
            DropIndex("dbo.TypeOfApplications", new[] { "PersonId" });
            CreateTable(
                "dbo.MedicalErrors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        NameAndForm = c.String(),
                        Strength = c.Double(nullable: false),
                        PathOfAdministration = c.String(),
                        Indication = c.String(),
                        Personnel = c.Int(nullable: false),
                        PartOfError = c.Int(nullable: false),
                        TypeOfError = c.Int(nullable: false),
                        TakeAnAction = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MedicalError_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AlterTableAnnotations(
                "dbo.NearMisses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        NameAndForm = c.String(),
                        Strength = c.Double(nullable: false),
                        PathOfAdministration = c.String(),
                        Indication = c.String(),
                        Personnel = c.Int(nullable: false),
                        PartOfError = c.Int(nullable: false),
                        CorrectiveMeasureTaken = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_NearMiss_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.People",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        ErrorDetectionDate = c.DateTime(),
                        AssignedCountryId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Person_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.NearMisses", "Description", c => c.String());
            AddColumn("dbo.NearMisses", "Personnel", c => c.Int(nullable: false));
            AddColumn("dbo.NearMisses", "PartOfError", c => c.Int(nullable: false));
            AddColumn("dbo.NearMisses", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "DeleterUserId", c => c.Long());
            AddColumn("dbo.NearMisses", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.NearMisses", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.NearMisses", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.NearMisses", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.NearMisses", "CreatorUserId", c => c.Long());
            AddColumn("dbo.People", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.People", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "DeleterUserId", c => c.Long());
            AddColumn("dbo.People", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.People", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.People", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.People", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "CreatorUserId", c => c.Long());
            AddColumn("dbo.TypeOfApplications", "MedicalErrorId", c => c.Int());
            AddColumn("dbo.TypeOfApplications", "FullName", c => c.String());
            AddColumn("dbo.TypeOfApplications", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.TypeOfApplications", "PlaceOfErrorDetection", c => c.Int(nullable: false));
            AlterColumn("dbo.NearMisses", "Strength", c => c.Double(nullable: false));
            AlterColumn("dbo.People", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.People", "ErrorDetectionDate", c => c.DateTime());
            AlterColumn("dbo.TypeOfApplications", "PersonId", c => c.Long(nullable: false));
            CreateIndex("dbo.NearMisses", "IsDeleted");
            CreateIndex("dbo.People", "IsDeleted");
            CreateIndex("dbo.TypeOfApplications", "MedicalErrorId");
            CreateIndex("dbo.TypeOfApplications", "PersonId");
            AddForeignKey("dbo.TypeOfApplications", "MedicalErrorId", "dbo.MedicalErrors", "Id");
            AddForeignKey("dbo.TypeOfApplications", "PersonId", "dbo.People", "Id", cascadeDelete: true);
            DropColumn("dbo.NearMisses", "DescriptionNearMiss");
            DropColumn("dbo.NearMisses", "Doctor");
            DropColumn("dbo.NearMisses", "Pharmacist");
            DropColumn("dbo.NearMisses", "Nurse");
            DropColumn("dbo.NearMisses", "Other1");
            DropColumn("dbo.NearMisses", "RewritingTherapy");
            DropColumn("dbo.NearMisses", "PrescribingTherapy");
            DropColumn("dbo.NearMisses", "PreparingTherapy");
            DropColumn("dbo.NearMisses", "AdministrationApplication");
            DropColumn("dbo.NearMisses", "Other2");
            DropColumn("dbo.People", "Male");
            DropColumn("dbo.People", "Female");
            DropColumn("dbo.People", "ErrorDetectionTime");
            DropColumn("dbo.People", "PlaceOfErrorDetectionId");
            DropTable("dbo.PlaceOfErrorDetections");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.People", "PlaceOfErrorDetectionId", c => c.Int());
            AddColumn("dbo.People", "ErrorDetectionTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.People", "Female", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "Male", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "Other2", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "AdministrationApplication", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "PreparingTherapy", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "PrescribingTherapy", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "RewritingTherapy", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "Other1", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "Nurse", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "Pharmacist", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "Doctor", c => c.Boolean(nullable: false));
            AddColumn("dbo.NearMisses", "DescriptionNearMiss", c => c.String());
            DropForeignKey("dbo.TypeOfApplications", "PersonId", "dbo.People");
            DropForeignKey("dbo.TypeOfApplications", "MedicalErrorId", "dbo.MedicalErrors");
            DropIndex("dbo.MedicalErrors", new[] { "IsDeleted" });
            DropIndex("dbo.TypeOfApplications", new[] { "PersonId" });
            DropIndex("dbo.TypeOfApplications", new[] { "MedicalErrorId" });
            DropIndex("dbo.People", new[] { "IsDeleted" });
            DropIndex("dbo.NearMisses", new[] { "IsDeleted" });
            AlterColumn("dbo.TypeOfApplications", "PersonId", c => c.Long());
            AlterColumn("dbo.People", "ErrorDetectionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.People", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NearMisses", "Strength", c => c.Int(nullable: false));
            DropColumn("dbo.TypeOfApplications", "PlaceOfErrorDetection");
            DropColumn("dbo.TypeOfApplications", "DateTime");
            DropColumn("dbo.TypeOfApplications", "FullName");
            DropColumn("dbo.TypeOfApplications", "MedicalErrorId");
            DropColumn("dbo.People", "CreatorUserId");
            DropColumn("dbo.People", "CreationTime");
            DropColumn("dbo.People", "LastModifierUserId");
            DropColumn("dbo.People", "LastModificationTime");
            DropColumn("dbo.People", "DeletionTime");
            DropColumn("dbo.People", "DeleterUserId");
            DropColumn("dbo.People", "IsDeleted");
            DropColumn("dbo.People", "Gender");
            DropColumn("dbo.NearMisses", "CreatorUserId");
            DropColumn("dbo.NearMisses", "CreationTime");
            DropColumn("dbo.NearMisses", "LastModifierUserId");
            DropColumn("dbo.NearMisses", "LastModificationTime");
            DropColumn("dbo.NearMisses", "DeletionTime");
            DropColumn("dbo.NearMisses", "DeleterUserId");
            DropColumn("dbo.NearMisses", "IsDeleted");
            DropColumn("dbo.NearMisses", "PartOfError");
            DropColumn("dbo.NearMisses", "Personnel");
            DropColumn("dbo.NearMisses", "Description");
            AlterTableAnnotations(
                "dbo.People",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        ErrorDetectionDate = c.DateTime(),
                        AssignedCountryId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Person_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.NearMisses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        NameAndForm = c.String(),
                        Strength = c.Double(nullable: false),
                        PathOfAdministration = c.String(),
                        Indication = c.String(),
                        Personnel = c.Int(nullable: false),
                        PartOfError = c.Int(nullable: false),
                        CorrectiveMeasureTaken = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_NearMiss_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropTable("dbo.MedicalErrors",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MedicalError_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            CreateIndex("dbo.TypeOfApplications", "PersonId");
            CreateIndex("dbo.People", "PlaceOfErrorDetectionId");
            AddForeignKey("dbo.TypeOfApplications", "PersonId", "dbo.People", "Id");
            AddForeignKey("dbo.People", "PlaceOfErrorDetectionId", "dbo.PlaceOfErrorDetections", "Id");
        }
    }
}
