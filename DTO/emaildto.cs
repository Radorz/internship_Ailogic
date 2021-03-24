using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class emaildto
    {
        [EmailAddress(ErrorMessage = "The Email is no valid")]
        [Required(ErrorMessage = "The email is required")]
        public string Email { get; set; }
       
    }
}
