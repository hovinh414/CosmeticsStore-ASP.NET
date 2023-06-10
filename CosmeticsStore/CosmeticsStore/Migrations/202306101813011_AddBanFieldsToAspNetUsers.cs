namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBanFieldsToAspNetUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BanExpirationDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "IsBanned", c => c.Boolean(nullable: false, defaultValue: false));
        }


        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsBanned");
            DropColumn("dbo.AspNetUsers", "BanExpirationDate");
        }

    }
}
