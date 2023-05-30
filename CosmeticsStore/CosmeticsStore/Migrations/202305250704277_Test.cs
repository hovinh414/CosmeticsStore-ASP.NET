namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Branchs", "Phone");
            DropColumn("dbo.tb_Branchs", "Map");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Branchs", "Map", c => c.String(maxLength: 150));
            AddColumn("dbo.tb_Branchs", "Phone", c => c.String(maxLength: 150));
        }
    }
}
