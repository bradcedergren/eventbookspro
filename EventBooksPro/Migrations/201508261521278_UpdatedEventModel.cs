namespace EventBooksPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEventModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "ApplicationUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "ApplicationUserId", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Name", c => c.String());
        }
    }
}
