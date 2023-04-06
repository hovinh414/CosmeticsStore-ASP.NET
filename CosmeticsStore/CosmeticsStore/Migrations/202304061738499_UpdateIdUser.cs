namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "IdUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "IdUser");
        }
    }
}
