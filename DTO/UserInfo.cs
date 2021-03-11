using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserInfo
    {

        [Required(ErrorMessage = "The user is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The password  is required")]
        public string Password { get; set; }    

    }
}
