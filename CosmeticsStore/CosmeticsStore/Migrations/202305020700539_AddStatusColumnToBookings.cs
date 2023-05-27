﻿namespace CosmeticsStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusColumnToBookings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Bookings", "Status", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.tb_Bookings", "Status");
        }

    }
}