using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class resetpassword
    {



        [Required(ErrorMessage = "The password  is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The confirmpassword  is required")]
        [Compare("Password", ErrorMessage = "The passwords fields do not match.")]
        public string confirmpassword { get; set; }
    }
}
