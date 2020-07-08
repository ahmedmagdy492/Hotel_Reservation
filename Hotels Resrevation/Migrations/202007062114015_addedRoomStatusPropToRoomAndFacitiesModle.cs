namespace Hotels_Resrevation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRoomStatusPropToRoomAndFacitiesModle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facilties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HotelId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.HotelId)
                .Index(t => t.HotelId);
            
            AddColumn("dbo.Rooms", "RoomStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.Facilties", "HotelId", "dbo.AspNetUsers");
            DropIndex("dbo.Facilties", new[] { "HotelId" });
            DropColumn("dbo.Rooms", "RoomStatus");
            DropTable("dbo.Facilties");
        }
    }
}
