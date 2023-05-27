namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateReview : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "CustomerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
