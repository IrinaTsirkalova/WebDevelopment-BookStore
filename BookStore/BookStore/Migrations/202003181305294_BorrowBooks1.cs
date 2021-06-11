namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BorrowBooks1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Book_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Book_id", c => c.Int(nullable: false));
        }
    }
}
