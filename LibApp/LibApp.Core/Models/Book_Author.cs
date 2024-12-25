using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class Book_Author
    {
        [Key]
        public int Id { get; set; }
        [Required,ForeignKey("book")]
        public int BookId { get; set; }

        public Book book { get; set; }


        [Required,ForeignKey("author")]
        public int AuthorId { get; set; }
        public Author author { get; set; }
    }
}
