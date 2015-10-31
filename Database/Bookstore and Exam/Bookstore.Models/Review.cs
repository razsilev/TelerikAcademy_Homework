using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required] 
        public DateTime CreatedOn { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
