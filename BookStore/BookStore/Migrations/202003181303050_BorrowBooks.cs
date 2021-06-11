namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BorrowBooks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Book_id", "dbo.Books");
            DropIndex("dbo.Users", new[] { "Book_id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Users", "Book_id");
            AddForeignKey("dbo.Users", "Book_id", "dbo.Books", "Book_Id", cascadeDelete: true);
        }
    }
}
