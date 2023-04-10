namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Posts", "Post_Id", "dbo.tb_Posts");
            DropIndex("dbo.tb_Posts", new[] { "Post_Id" });
            DropColumn("dbo.tb_Posts", "Post_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Posts", "Post_Id", c => c.Int());
            CreateIndex("dbo.tb_Posts", "Post_Id");
            AddForeignKey("dbo.tb_Posts", "Post_Id", "dbo.tb_Posts", "Id");
        }
    }
}
