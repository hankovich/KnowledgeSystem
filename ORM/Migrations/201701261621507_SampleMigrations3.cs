namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Company", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Phone", c => c.String(maxLength: 11));
            AlterColumn("dbo.Users", "City", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "City", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Users", "Company", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
