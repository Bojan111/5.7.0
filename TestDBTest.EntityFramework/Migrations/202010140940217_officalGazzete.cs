namespace TestDBTest.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class officalGazzete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManufacturerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManufacturName = c.String(),
                        ManufaturAddress = c.String(),
                        NumberOfMedicalDevice = c.Int(nullable: false),
                        DateOfFillForm = c.DateTime(nullable: false),
                        ApplicantHealthInstitution = c.String(),
                        ApplicantFullNameHealthWorker = c.String(),
                        ApplicantAddress = c.String(),
                        ApplicantPhone = c.Int(nullable: false),
                        ApplicantEmail = c.String(),
                        Signature = c.String(),
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
                    { "DynamicFilter_ManufacturerInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.MedicalDeviceInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuspectedMedicalDevice = c.String(),
                        MethodOfApplication = c.String(),
                        IndicationOfUse = c.String(),
                        DateOfUseMedicalDevice = c.DateTime(),
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
                    { "DynamicFilter_MedicalDeviceInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.OfficialGazzetes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationForUnwantedMedDevices = c.String(),
                        Number = c.Long(nullable: false),
                        PersonId = c.Long(nullable: false),
                        MedicalDeviceInfoId = c.Int(nullable: false),
                        UseOfMedicalDevicesId = c.Int(nullable: false),
                        ManufacturerInfoId = c.Int(nullable: false),
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
                    { "DynamicFilter_OfficialGazzete_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ManufacturerInfoes", t => t.ManufacturerInfoId, cascadeDelete: true)
                .ForeignKey("dbo.MedicalDeviceInfoes", t => t.MedicalDeviceInfoId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.UseOfMedicalDevices", t => t.UseOfMedicalDevicesId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.MedicalDeviceInfoId)
                .Index(t => t.UseOfMedicalDevicesId)
                .Index(t => t.ManufacturerInfoId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.UseOfMedicalDevices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConcomitantUseOfOtherMedicalDevices = c.String(),
                        OtherRelevantInformation = c.String(),
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
                    { "DynamicFilter_UseOfMedicalDevices_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.People", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.People", "OnsetOfAdverseReactions", c => c.DateTime());
            AddColumn("dbo.People", "DescribeYourAdverseReaction", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficialGazzetes", "UseOfMedicalDevicesId", "dbo.UseOfMedicalDevices");
            DropForeignKey("dbo.OfficialGazzetes", "PersonId", "dbo.People");
            DropForeignKey("dbo.OfficialGazzetes", "MedicalDeviceInfoId", "dbo.MedicalDeviceInfoes");
            DropForeignKey("dbo.OfficialGazzetes", "ManufacturerInfoId", "dbo.ManufacturerInfoes");
            DropIndex("dbo.UseOfMedicalDevices", new[] { "IsDeleted" });
            DropIndex("dbo.OfficialGazzetes", new[] { "IsDeleted" });
            DropIndex("dbo.OfficialGazzetes", new[] { "ManufacturerInfoId" });
            DropIndex("dbo.OfficialGazzetes", new[] { "UseOfMedicalDevicesId" });
            DropIndex("dbo.OfficialGazzetes", new[] { "MedicalDeviceInfoId" });
            DropIndex("dbo.OfficialGazzetes", new[] { "PersonId" });
            DropIndex("dbo.MedicalDeviceInfoes", new[] { "IsDeleted" });
            DropIndex("dbo.ManufacturerInfoes", new[] { "IsDeleted" });
            DropColumn("dbo.People", "DescribeYourAdverseReaction");
            DropColumn("dbo.People", "OnsetOfAdverseReactions");
            DropColumn("dbo.People", "Age");
            DropTable("dbo.UseOfMedicalDevices",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UseOfMedicalDevices_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.OfficialGazzetes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OfficialGazzete_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.MedicalDeviceInfoes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MedicalDeviceInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ManufacturerInfoes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ManufacturerInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
