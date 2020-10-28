﻿namespace TestDBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeOfApplications", "PlaceOfCreationError", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeOfApplications", "PlaceOfCreationError");
        }
    }
}
