namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfficialGazzetes", "PersonId", "dbo.People");
            DropIndex("dbo.OfficialGazzetes", new[] { "PersonId" });
            AlterColumn("dbo.OfficialGazzetes", "PersonId", c => c.Long());
            CreateIndex("dbo.OfficialGazzetes", "PersonId");
            AddForeignKey("dbo.OfficialGazzetes", "PersonId", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficialGazzetes", "PersonId", "dbo.People");
            DropIndex("dbo.OfficialGazzetes", new[] { "PersonId" });
            AlterColumn("dbo.OfficialGazzetes", "PersonId", c => c.Long(nullable: false));
            CreateIndex("dbo.OfficialGazzetes", "PersonId");
            AddForeignKey("dbo.OfficialGazzetes", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
