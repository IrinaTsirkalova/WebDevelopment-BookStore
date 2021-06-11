namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatemig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "AvailableCopies");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AvailableCopies", c => c.Int(nullable: false));
        }
    }
}
