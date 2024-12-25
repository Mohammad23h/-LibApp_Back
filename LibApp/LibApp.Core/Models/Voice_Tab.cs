using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models
{
    public class Voice_Tab
    {
        public int Id { get; set; }
        [ForeignKey("voice")]
        public int VoiceId { get; set; }
        public Voice voice { get; set; }

        [ForeignKey("tab")]
        public int TabId { get; set; }
        public Tab tab { get; set; }
        public TimeOnly StartTime { get; set; }
        public int StartPage { get; set; }
        public int OrderNum { get; set; }
    }
}
