namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        id = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false),
                        Login = c.String(nullable: false, maxLength: 30, unicode: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        Password = c.String(nullable: false, maxLength: 256, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        Company = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 11),
                        City = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserSkill",
                c => new
                    {
                        id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        id = c.Int(nullable: false),
                        SkillCategoryId = c.Int(nullable: false),
                        SkillName = c.String(nullable: false, maxLength: 30, unicode: false),
                        SkillLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SkillCategory", t => t.SkillCategoryId)
                .Index(t => t.SkillCategoryId);
            
            CreateTable(
                "dbo.SkillCategory",
                c => new
                    {
                        id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserSkill", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserSkill", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.Skills", "SkillCategoryId", "dbo.SkillCategory");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropIndex("dbo.Skills", new[] { "SkillCategoryId" });
            DropIndex("dbo.UserSkill", new[] { "SkillId" });
            DropIndex("dbo.UserSkill", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropTable("dbo.SkillCategory");
            DropTable("dbo.Skills");
            DropTable("dbo.UserSkill");
            DropTable("dbo.Users");
            DropTable("dbo.UserRole");
            DropTable("dbo.Roles");
        }
    }
}
