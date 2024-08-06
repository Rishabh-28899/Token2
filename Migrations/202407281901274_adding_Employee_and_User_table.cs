﻿using System.Data.Entity.Migrations;

namespace Token_2.Migrations
{
    public partial class adding_Employee_and_User_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Email = c.String(),
                    Gender = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    UserName = c.String(),
                    Password = c.String(),
                    Roles = c.String(),
                    Email = c.String(),
                })
                .PrimaryKey(t => t.UserId);

        }

        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
        }
    }
}
