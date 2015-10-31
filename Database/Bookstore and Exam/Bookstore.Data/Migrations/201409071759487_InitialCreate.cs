namespace Bookstore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AuthorId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ISBN = c.String(maxLength: 13),
                        Price = c.Decimal(precision: 18, scale: 2),
                        WebSite = c.String(),
                    })
                .PrimaryKey(t => t.BookId)
                .Index(t => t.ISBN, unique: true);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        BookId = c.Int(nullable: false),
                        AuthorId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_BookId = c.Int(nullable: false),
                        Author_AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_BookId, t.Author_AuthorId })
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId, cascadeDelete: true)
                .Index(t => t.Book_BookId)
                .Index(t => t.Author_AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "BookId", "dbo.Books");
            DropForeignKey("dbo.Reviews", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "Author_AuthorId" });
            DropIndex("dbo.BookAuthors", new[] { "Book_BookId" });
            DropIndex("dbo.Reviews", new[] { "AuthorId" });
            DropIndex("dbo.Reviews", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "ISBN" });
            DropIndex("dbo.Authors", new[] { "Name" });
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Reviews");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
