namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gazette_deleted_prop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OfficialGazzetes", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OfficialGazzetes", "Number", c => c.Long(nullable: false));
        }
    }
}
