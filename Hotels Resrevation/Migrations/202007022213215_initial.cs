namespace Hotels_Resrevation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsProfileImg = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationTime = c.DateTime(nullable: false),
                        StartDay = c.DateTime(nullable: false),
                        EndDay = c.DateTime(nullable: false),
                        DayCount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsPayingFinished = c.Boolean(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        AmountLeft = c.Double(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Capcity = c.Int(nullable: false),
                        IsSuite = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                        HotelId = c.String(maxLength: 128),
                        ReservationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.HotelId)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.HotelId)
                .Index(t => t.ReservationId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Rating = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        HotelId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.HotelId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.UserId)
                .Index(t => t.HotelId)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserImages", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "HotelId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Reviews", new[] { "HotelId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Rooms", new[] { "ReservationId" });
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropIndex("dbo.UserImages", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "Location");
            DropTable("dbo.Reviews");
            DropTable("dbo.Rooms");
            DropTable("dbo.Reservations");
            DropTable("dbo.UserImages");
        }
    }
}
