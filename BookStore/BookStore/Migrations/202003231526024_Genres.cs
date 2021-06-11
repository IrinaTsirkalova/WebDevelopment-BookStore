namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenresId = c.Int(nullable: false, identity: true),
                        GenresName = c.String(),
                    })
                .PrimaryKey(t => t.GenresId);
            
            AddColumn("dbo.Books", "GenresId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "GenresId");
            AddForeignKey("dbo.Books", "GenresId", "dbo.Genres", "GenresId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenresId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenresId" });
            DropColumn("dbo.Books", "GenresId");
            DropTable("dbo.Genres");
        }
    }
}
