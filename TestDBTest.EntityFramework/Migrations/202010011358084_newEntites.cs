﻿namespace TestDBTest.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class newEntites : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.People",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);



            CreateTable(
                "dbo.Tasks",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    AssignedPersonId = c.Int(),
                    Description = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    State = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.AssignedPersonId)
                .Index(t => t.AssignedPersonId);



        }
        
        public override void Down()
        {

            DropForeignKey("dbo.Tasks", "AssignedPersonId", "dbo.People");

            DropIndex("dbo.Tasks", new[] { "AssignedPersonId" });

            DropTable("dbo.Tasks");

            DropTable("dbo.People");

        }
    }
}
