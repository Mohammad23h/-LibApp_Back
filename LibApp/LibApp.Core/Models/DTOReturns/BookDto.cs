using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models.DTOReturns
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // the next properity is the Book Evalution
        public int BookEv { get; set; }
        [AllowNull]
        public ICollection<Author> authors { get; set; } = null;
        
    }
}
