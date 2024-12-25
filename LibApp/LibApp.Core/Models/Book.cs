using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // the next properity is the Book Evalution
        public int BookEv { get; set; }

        // the next properirty is The Count of Lesteners
        
        public int LestenersCnt { get{
                int cnt = 0;
                foreach (var item in readings)
                {
                    cnt += item.lestenings.Count();
                }
                return cnt;
            } }
        

        public ICollection<Reading> readings { get; set; }
        public ICollection<Book_Author> bookAuthors { get; set; }
        public ICollection<BookReview> bookReviews { get; set; }
    }
}
