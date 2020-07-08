namespace Hotels_Resrevation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedReserverDateFromReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "ReservationTime");
            DropColumn("dbo.Reservations", "StartDay");
            DropColumn("dbo.Reservations", "EndDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "EndDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "StartDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "ReservationTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "EndDate");
            DropColumn("dbo.Reservations", "StartDate");
        }
    }
}
