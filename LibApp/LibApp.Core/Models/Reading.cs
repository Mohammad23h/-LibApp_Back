using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class Reading
    {
        [Key]
        public int Id { get; set; }

        [Required,ForeignKey("book")]
        public int BookId { get; set; }
        public Book book { get; set; }

        [Required, ForeignKey("reader")]
        public string ReaderId { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public AppUser reader { get; set; }

        /*
        public int ReadingEv { get{
                var books = book.bookReviews.Where(b => b.ReadingId == this.Id);
                int ev = 0 , cnt = 0;

                foreach (var item in books)
                {
                    ev += item.ReadingEv;
                    cnt++;
                }
                return ev;
            } }
       */ 
        public ICollection<Lestening> lestenings { get; set; }
    }
}
