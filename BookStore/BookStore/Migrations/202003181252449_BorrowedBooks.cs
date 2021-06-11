namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BorrowedBooks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Borroweds", "BookId", "dbo.Books");
            DropIndex("dbo.Borroweds", new[] { "BookId" });
            CreateTable(
                "dbo.BorrowedBooks",
                c => new
                    {
                        Borrow_Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        PersonFirstName = c.String(),
                        PersonLastName = c.String(),
                        numBook = c.Int(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Borrow_Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "Book_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "Book_id");
            AddForeignKey("dbo.Users", "Book_id", "dbo.Books", "Book_Id", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Borroweds",
                c => new
                    {
                        Person_Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        PersonFirstName = c.String(),
                        PersonLastName = c.String(),
                        numBook = c.Int(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Person_Id);
            
            DropForeignKey("dbo.BorrowedBooks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Book_id", "dbo.Books");
            DropForeignKey("dbo.BorrowedBooks", "BookId", "dbo.Books");
            DropIndex("dbo.Users", new[] { "Book_id" });
            DropIndex("dbo.BorrowedBooks", new[] { "UserId" });
            DropIndex("dbo.BorrowedBooks", new[] { "BookId" });
            DropColumn("dbo.Users", "Book_id");
            DropTable("dbo.BorrowedBooks");
            CreateIndex("dbo.Borroweds", "BookId");
            AddForeignKey("dbo.Borroweds", "BookId", "dbo.Books", "Book_Id", cascadeDelete: false);
        }
    }
}
