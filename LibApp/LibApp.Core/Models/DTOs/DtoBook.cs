using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models.DTOs
{
    public class DtoBook
    {
        public string Title { get; set; }

        public string Description { get; set; } = "";
        public string ImageUrl { get; set; }
        public int AuthorId { get; set; } = -1;
        public HashSet<int> AuthorIds { get; set; }
        public HashSet<int> ClassifyIds { get; set; }
    }
}
