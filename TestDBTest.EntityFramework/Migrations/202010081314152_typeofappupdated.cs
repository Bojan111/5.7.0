namespace TestDBTest.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class typeofappupdated : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TypeOfApplications");
            AlterTableAnnotations(
                "dbo.TypeOfApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NearMissId = c.Int(),
                        MedicalErrorId = c.Int(),
                        PersonId = c.Long(nullable: false),
                        FullName = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        PlaceOfErrorDetection = c.Int(nullable: false),
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
                        "DynamicFilter_TypeOfApplication_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.TypeOfApplications", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.TypeOfApplications", "DeleterUserId", c => c.Long());
            AddColumn("dbo.TypeOfApplications", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.TypeOfApplications", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.TypeOfApplications", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.TypeOfApplications", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.TypeOfApplications", "CreatorUserId", c => c.Long());
            AlterColumn("dbo.TypeOfApplications", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TypeOfApplications", "Id");
            CreateIndex("dbo.TypeOfApplications", "IsDeleted");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TypeOfApplications", new[] { "IsDeleted" });
            DropPrimaryKey("dbo.TypeOfApplications");
            AlterColumn("dbo.TypeOfApplications", "Id", c => c.Long(nullable: false, identity: true));
            DropColumn("dbo.TypeOfApplications", "CreatorUserId");
            DropColumn("dbo.TypeOfApplications", "CreationTime");
            DropColumn("dbo.TypeOfApplications", "LastModifierUserId");
            DropColumn("dbo.TypeOfApplications", "LastModificationTime");
            DropColumn("dbo.TypeOfApplications", "DeletionTime");
            DropColumn("dbo.TypeOfApplications", "DeleterUserId");
            DropColumn("dbo.TypeOfApplications", "IsDeleted");
            AlterTableAnnotations(
                "dbo.TypeOfApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NearMissId = c.Int(),
                        MedicalErrorId = c.Int(),
                        PersonId = c.Long(nullable: false),
                        FullName = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        PlaceOfErrorDetection = c.Int(nullable: false),
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
                        "DynamicFilter_TypeOfApplication_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AddPrimaryKey("dbo.TypeOfApplications", "Id");
        }
    }
}
