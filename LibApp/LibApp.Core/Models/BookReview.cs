using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class BookReview
    {
        [Key]
        public int Id { get; set; }

        [Required,ForeignKey("book")]
        public int BookId { get; set; }
        public Book book { get; set; }

        [Required]
        public int BookEv { get; set; }

        [Required, ForeignKey("reading")]
        public int ReadingId { get; set; }
        //public Reading reading { get; set; }

        [Required]
        public int ReadingEv { get; set; }

        [Required, ForeignKey("user")]
        public string UserId { get; set; }
        public AppUser user { get; set; }
        public ICollection<BookComment> BkComments { get; set; }

    }
}
