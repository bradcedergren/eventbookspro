namespace EventBooksPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "EventTypesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventTypesId", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "EventTypeId");
        }
    }
}
