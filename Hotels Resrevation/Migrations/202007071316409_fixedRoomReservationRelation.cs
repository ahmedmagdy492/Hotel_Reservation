namespace Hotels_Resrevation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedRoomReservationRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.Rooms", new[] { "ReservationId" });
            AddColumn("dbo.Reservations", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "RoomId");
            AddForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "ReservationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "ReservationId", c => c.Int());
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropColumn("dbo.Reservations", "RoomId");
            CreateIndex("dbo.Rooms", "ReservationId");
            AddForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations", "Id");
        }
    }
}
