namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
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
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SkillCategory",
                c => new
                    {
                        id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
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
                "dbo.UserSkill",
                c => new
                    {
                        id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Skills", t => t.SkillId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Login = c.String(maxLength: 30, fixedLength: true),
                        Email = c.String(maxLength: 30, fixedLength: true),
                        Password = c.String(maxLength: 256, fixedLength: true),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        City = c.String(maxLength: 20, fixedLength: true),
                        FirstName = c.String(maxLength: 30, fixedLength: true),
                        LastName = c.String(maxLength: 30, fixedLength: true),
                        Company = c.String(maxLength: 50, fixedLength: true),
                        Phone = c.String(maxLength: 11, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "SkillCategoryId", "dbo.SkillCategory");
            DropForeignKey("dbo.UserSkill", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserSkill", new[] { "SkillId" });
            DropIndex("dbo.Skills", new[] { "SkillCategoryId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropTable("dbo.User");
            DropTable("dbo.UserSkill");
            DropTable("dbo.Skills");
            DropTable("dbo.SkillCategory");
            DropTable("dbo.UserRole");
            DropTable("dbo.Roles");
            DropTable("dbo.__MigrationHistory");
        }
    }
}
