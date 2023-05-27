namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomerIdForReviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "CustomerId");
        }
    }
}
