namespace MyBlogs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
