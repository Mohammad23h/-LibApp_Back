using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class Voice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int ReadingId { get; set; }
    }
}
