namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "StarRating", c => c.Single(nullable: false));
            AddColumn("dbo.Reviews", "ProductId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "ProductId");
            DropColumn("dbo.tb_Product", "StarRating");
        }
    }
}
