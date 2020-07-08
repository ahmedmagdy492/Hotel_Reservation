namespace Hotels_Resrevation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedSomeRedauntantPropsFromReservations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "IsPayingFinished");
            DropColumn("dbo.Reservations", "AmountPaid");
            DropColumn("dbo.Reservations", "AmountLeft");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "AmountLeft", c => c.Double(nullable: false));
            AddColumn("dbo.Reservations", "AmountPaid", c => c.Double(nullable: false));
            AddColumn("dbo.Reservations", "IsPayingFinished", c => c.Boolean(nullable: false));
        }
    }
}
