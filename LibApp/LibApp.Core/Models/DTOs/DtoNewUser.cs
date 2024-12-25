using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Core.Models.DTOs
{
    public class DtoNewUser
    {
        [Required]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string password { get; set; }
        public string role { get; set; } = RoleName.NormalUser;
    }
}
