using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class Lestening
    {
        [Key]
        public int Id { get; set; }
        [Required,ForeignKey("lestener")]
        public string LestenerId { get; set; }
        public AppUser lestener { get; set; }

        [Required,ForeignKey("reading")]
        public int ReadingId { get; set; }
        //public Reading reading { get; set; }
    }
}
