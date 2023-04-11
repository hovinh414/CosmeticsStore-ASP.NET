namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBooking1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_BookingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bookings_Id = c.Int(),
                        Branchs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Bookings", t => t.Bookings_Id)
                .ForeignKey("dbo.tb_Branchs", t => t.Branchs_Id)
                .ForeignKey("dbo.tb_Service", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.Bookings_Id)
                .Index(t => t.Branchs_Id);
            
            CreateTable(
                "dbo.tb_Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TimeStart = c.DateTime(nullable: false),
                        TimeFinish = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Service",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(),
                        ServiceCode = c.String(maxLength: 50),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ServiceCategoryId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_ServiceImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        Image = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Service", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ServiceImage", "ServiceId", "dbo.tb_Service");
            DropForeignKey("dbo.tb_BookingDetails", "ServiceId", "dbo.tb_Service");
            DropForeignKey("dbo.tb_BookingDetails", "Branchs_Id", "dbo.tb_Branchs");
            DropForeignKey("dbo.tb_BookingDetails", "Bookings_Id", "dbo.tb_Bookings");
            DropIndex("dbo.tb_ServiceImage", new[] { "ServiceId" });
            DropIndex("dbo.tb_BookingDetails", new[] { "Branchs_Id" });
            DropIndex("dbo.tb_BookingDetails", new[] { "Bookings_Id" });
            DropIndex("dbo.tb_BookingDetails", new[] { "ServiceId" });
            DropTable("dbo.tb_ServiceImage");
            DropTable("dbo.tb_Service");
            DropTable("dbo.tb_Bookings");
            DropTable("dbo.tb_BookingDetails");
        }
    }
}
