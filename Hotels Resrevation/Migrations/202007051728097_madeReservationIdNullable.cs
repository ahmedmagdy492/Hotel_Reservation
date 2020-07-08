namespace Hotels_Resrevation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeReservationIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.Rooms", new[] { "ReservationId" });
            AlterColumn("dbo.Rooms", "ReservationId", c => c.Int());
            CreateIndex("dbo.Rooms", "ReservationId");
            AddForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.Rooms", new[] { "ReservationId" });
            AlterColumn("dbo.Rooms", "ReservationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "ReservationId");
            AddForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations", "Id", cascadeDelete: true);
        }
    }
}
