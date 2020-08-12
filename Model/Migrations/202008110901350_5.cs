namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "TotalCount");
            DropColumn("dbo.Orders", "PageSize");
            DropColumn("dbo.Orders", "PageIndex");
            DropColumn("dbo.Orders", "ShipState");
            DropColumn("dbo.Orders", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Orders", "ShipState", c => c.Int());
            AddColumn("dbo.Orders", "PageIndex", c => c.Int());
            AddColumn("dbo.Orders", "PageSize", c => c.Int());
            AddColumn("dbo.Orders", "TotalCount", c => c.Int());
        }
    }
}
