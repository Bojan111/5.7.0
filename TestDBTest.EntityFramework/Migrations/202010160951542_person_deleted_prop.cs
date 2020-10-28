namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class person_deleted_prop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "OnsetOfAdverseReactions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "OnsetOfAdverseReactions", c => c.DateTime());
        }
    }
}
