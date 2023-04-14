namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentSetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_PaymentSetting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlVNP = c.String(maxLength: 150),
                        ReturnUrlVNP = c.String(maxLength: 150),
                        TmnCodeVNP = c.String(maxLength: 150),
                        HashSecretVNP = c.String(maxLength: 150),
                        EndpointMomo = c.String(maxLength: 150),
                        PartnerCodeMomo = c.String(maxLength: 150),
                        AccessKeyMomo = c.String(maxLength: 150),
                        SerectkeyMomo = c.String(maxLength: 150),
                        OrderInfoMomo = c.String(maxLength: 150),
                        ReturnUrlMomo = c.String(maxLength: 150),
                        NotifyurlMomo = c.String(maxLength: 150),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_PaymentSetting");
        }
    }
}
