using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class AuthorReview
    {
        [Key]
        public int Id { get; set; }

        [Required,ForeignKey("author")]
        public int AuthorId { get; set; }
        public Author author { get; set; }

        [Required]
        public int AuthorEv { get; set; }

        [Required,ForeignKey("user")]
        public string UserId { get; set; }
        public AppUser user { get; set; }
        public ICollection<AuthorComment> authorComments { get; set; }
    }
}
