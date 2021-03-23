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

    }
}
