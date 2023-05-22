namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateForBookingsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Bookings", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Bookings", "TotalAmount", c => c.Int(nullable: false));
        }
    }
}
