using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class BooksAuthors
    {
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        public int SectionsWritten { get; set; }
    }
}
