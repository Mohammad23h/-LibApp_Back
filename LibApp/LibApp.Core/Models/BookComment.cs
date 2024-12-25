using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class BookComment
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        [Required,ForeignKey("bkReview")]
        public int BkReviewId { get; set; }
        //public BookReview bkReview { get; set; }
    }
}
