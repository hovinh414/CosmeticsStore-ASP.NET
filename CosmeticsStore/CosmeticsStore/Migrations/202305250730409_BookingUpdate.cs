namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingUpdate : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.tb_BookingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.String(),
                        ServiceId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceName = c.String(),
                        ServiceDetail = c.String(),
                        Bookings_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Bookings", t => t.Bookings_Id)
                .ForeignKey("dbo.tb_Service", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.Bookings_Id);
            
            CreateTable(
                "dbo.tb_Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Date = c.String(),
                        serviceId = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            
        }
    }
}
