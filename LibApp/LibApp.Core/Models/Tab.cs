using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class Tab
    {
        public enum TabType { Public = 0 , Private = 1 }
        public int Id { get; set; }
        public int Name { get; set; }

        [ForeignKey("book")]
        public int BookId { get; set; }
        public Book book { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        //the next properity is the count of the pages in this tab
        public int PagesCnt { get {
                return EndPage - StartPage + 1;
            }
        }

        //the next properity is the Type of the tab (private or public)
        public TabType Type { get; set; } = TabType.Public;
    }
}
