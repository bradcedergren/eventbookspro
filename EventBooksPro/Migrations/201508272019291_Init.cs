namespace EventBooksPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "ApplicationUserId", c => c.String());
            AlterColumn("dbo.Clients", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Phone", c => c.String());
            DropColumn("dbo.Clients", "ApplicationUserId");
        }
    }
}
