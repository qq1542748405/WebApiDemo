namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalCount", c => c.Int());
            AddColumn("dbo.Orders", "PageSize", c => c.Int());
            AddColumn("dbo.Orders", "PageIndex", c => c.Int());
            AddColumn("dbo.Orders", "ShipState", c => c.Int());
            AddColumn("dbo.Orders", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Orders", "IsShipped", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "IsShipped", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Discriminator");
            DropColumn("dbo.Orders", "ShipState");
            DropColumn("dbo.Orders", "PageIndex");
            DropColumn("dbo.Orders", "PageSize");
            DropColumn("dbo.Orders", "TotalCount");
        }
    }
}
