namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserSkill", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserSkill", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.Skills", "SkillCategoryId", "dbo.SkillCategory");
            DropPrimaryKey("dbo.UserRole");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.UserSkill");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.SkillCategory");
            AlterColumn("dbo.UserRole", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserSkill", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Skills", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SkillCategory", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserRole", "id");
            AddPrimaryKey("dbo.Users", "id");
            AddPrimaryKey("dbo.UserSkill", "id");
            AddPrimaryKey("dbo.Skills", "id");
            AddPrimaryKey("dbo.SkillCategory", "id");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.Users", "id");
            AddForeignKey("dbo.UserSkill", "UserId", "dbo.Users", "id");
            AddForeignKey("dbo.UserSkill", "SkillId", "dbo.Skills", "id");
            AddForeignKey("dbo.Skills", "SkillCategoryId", "dbo.SkillCategory", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "SkillCategoryId", "dbo.SkillCategory");
            DropForeignKey("dbo.UserSkill", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.UserSkill", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.SkillCategory");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.UserSkill");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.UserRole");
            AlterColumn("dbo.SkillCategory", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Skills", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.UserSkill", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRole", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SkillCategory", "id");
            AddPrimaryKey("dbo.Skills", "id");
            AddPrimaryKey("dbo.UserSkill", "id");
            AddPrimaryKey("dbo.Users", "id");
            AddPrimaryKey("dbo.UserRole", "id");
            AddForeignKey("dbo.Skills", "SkillCategoryId", "dbo.SkillCategory", "id");
            AddForeignKey("dbo.UserSkill", "SkillId", "dbo.Skills", "id");
            AddForeignKey("dbo.UserSkill", "UserId", "dbo.Users", "id");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.Users", "id");
        }
    }
}
