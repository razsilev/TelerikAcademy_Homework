using Bookstore.Data.Migrations;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext()
            :base("BookstoreConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreDbContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Review> Reviews { get; set; }
    }
}
