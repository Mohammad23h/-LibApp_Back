using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models.DTOReturns
{
    public class ReadingDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book book { get; set; }
        public string ReaderId { get; set; }
        public string ReaderName { get; set; }
        public DateTime PublishDate { get; set; } 

    }
}
