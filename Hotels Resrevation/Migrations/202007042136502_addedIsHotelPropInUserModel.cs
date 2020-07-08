namespace Hotels_Resrevation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsHotelPropInUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsHotel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsHotel");
        }
    }
}
