namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Roles", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Roles", "id");
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Roles", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Roles", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Roles", "id");
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Roles", "id");
        }
    }
}
