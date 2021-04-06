using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class statusdto
    {
        [Required(ErrorMessage = "The status is required")]
        public string Status { get; set; }
       
    }
}
