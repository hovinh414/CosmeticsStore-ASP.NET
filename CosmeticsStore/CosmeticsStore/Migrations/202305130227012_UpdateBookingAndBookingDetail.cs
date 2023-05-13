namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookingAndBookingDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_BookingDetails", "Branchs_Id", "dbo.tb_Branchs");
            DropIndex("dbo.tb_BookingDetails", new[] { "Branchs_Id" });
            AddColumn("dbo.tb_BookingDetails", "ServiceName", c => c.String());
            AddColumn("dbo.tb_BookingDetails", "ServiceDetail", c => c.String());
            AddColumn("dbo.tb_Bookings", "Status", c => c.String(nullable: false));
            AddColumn("dbo.tb_Bookings", "serviceId", c => c.String());
            AlterColumn("dbo.tb_BookingDetails", "BookingId", c => c.String());
            AlterColumn("dbo.tb_Bookings", "Date", c => c.String());
            DropColumn("dbo.tb_BookingDetails", "BranchId");
            DropColumn("dbo.tb_BookingDetails", "Branchs_Id");
            DropColumn("dbo.tb_Bookings", "Email");
            DropColumn("dbo.tb_Bookings", "TimeStart");
            DropColumn("dbo.tb_Bookings", "TimeFinish");
            DropColumn("dbo.tb_Bookings", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Bookings", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.tb_Bookings", "TimeFinish", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Bookings", "TimeStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Bookings", "Email", c => c.String(nullable: false));
            AddColumn("dbo.tb_BookingDetails", "Branchs_Id", c => c.Int());
            AddColumn("dbo.tb_BookingDetails", "BranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Bookings", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_BookingDetails", "BookingId", c => c.Int(nullable: false));
            DropColumn("dbo.tb_Bookings", "serviceId");
            DropColumn("dbo.tb_Bookings", "Status");
            DropColumn("dbo.tb_BookingDetails", "ServiceDetail");
            DropColumn("dbo.tb_BookingDetails", "ServiceName");
            CreateIndex("dbo.tb_BookingDetails", "Branchs_Id");
            AddForeignKey("dbo.tb_BookingDetails", "Branchs_Id", "dbo.tb_Branchs", "Id");
        }
    }
}
