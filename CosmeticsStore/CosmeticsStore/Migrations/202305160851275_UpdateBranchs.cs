namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBranchs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Branchs", "Phone", c => c.String(maxLength: 150));
            AddColumn("dbo.tb_Branchs", "Map", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Branchs", "Map");
            DropColumn("dbo.tb_Branchs", "Phone");
        }
    }
}
