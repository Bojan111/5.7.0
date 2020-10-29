namespace TestDBTest.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class newEntityListOfInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListOfInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Long(),
                        AssignedCountryId = c.Int(),
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
                    { "DynamicFilter_ListOfInformation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.AssignedCountryId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.AssignedCountryId)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListOfInformations", "PersonId", "dbo.People");
            DropForeignKey("dbo.ListOfInformations", "AssignedCountryId", "dbo.Countries");
            DropIndex("dbo.ListOfInformations", new[] { "IsDeleted" });
            DropIndex("dbo.ListOfInformations", new[] { "AssignedCountryId" });
            DropIndex("dbo.ListOfInformations", new[] { "PersonId" });
            DropTable("dbo.ListOfInformations",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ListOfInformation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
