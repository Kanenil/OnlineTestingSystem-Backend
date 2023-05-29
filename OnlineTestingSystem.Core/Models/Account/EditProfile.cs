using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Models.Account
{
    public class EditProfile
    {
        [Required()]
        public string FirstName { get; set; }
        [Required()]
        public string LastName { get; set; }
        public string? Image { get; set; }
        public string? BackgroundImage { get; set; }
    }
}
