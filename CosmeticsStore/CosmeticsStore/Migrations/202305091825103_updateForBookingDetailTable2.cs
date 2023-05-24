namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateForBookingDetailTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_BookingDetails", "ServiceName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_BookingDetails", "ServiceName");
        }
    }
}
