namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateForBookingDetailTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_BookingDetails", "Branchs_Id", "dbo.tb_Branchs");
            DropIndex("dbo.tb_BookingDetails", new[] { "Branchs_Id" });
            AddColumn("dbo.tb_BookingDetails", "ServiceDetail", c => c.String());
            AlterColumn("dbo.tb_BookingDetails", "BookingId", c => c.String());
            DropColumn("dbo.tb_BookingDetails", "BranchId");
            DropColumn("dbo.tb_BookingDetails", "Branchs_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_BookingDetails", "Branchs_Id", c => c.Int());
            AddColumn("dbo.tb_BookingDetails", "BranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_BookingDetails", "BookingId", c => c.Int(nullable: false));
            DropColumn("dbo.tb_BookingDetails", "ServiceDetail");
            CreateIndex("dbo.tb_BookingDetails", "Branchs_Id");
            AddForeignKey("dbo.tb_BookingDetails", "Branchs_Id", "dbo.tb_Branchs", "Id");
        }
    }
}
