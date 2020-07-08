namespace Hotels_Resrevation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRoomImagesModelAndTypePropOnRoomModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            AddColumn("dbo.Rooms", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomImages", "RoomId", "dbo.Rooms");
            DropIndex("dbo.RoomImages", new[] { "RoomId" });
            DropColumn("dbo.Rooms", "Type");
            DropTable("dbo.RoomImages");
        }
    }
}
