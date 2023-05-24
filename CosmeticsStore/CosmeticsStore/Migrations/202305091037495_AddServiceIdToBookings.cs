namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceIdToBookings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Bookings", "serviceId", c => c.String(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.tb_Bookings", "serviceId");
        }
    }
}
