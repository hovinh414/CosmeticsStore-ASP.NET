namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsBanned", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "BanExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BanExpirationDate");
            DropColumn("dbo.AspNetUsers", "IsBanned");
        }
    }
}
