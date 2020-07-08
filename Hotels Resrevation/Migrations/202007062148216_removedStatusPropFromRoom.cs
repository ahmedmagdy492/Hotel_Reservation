namespace Hotels_Resrevation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedStatusPropFromRoom : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "RoomStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomStatus", c => c.Int(nullable: false));
        }
    }
}
