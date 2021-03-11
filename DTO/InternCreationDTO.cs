using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class InternCreationDTO
    {
        [Required(ErrorMessage = "The Name is required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "The LasName is required")]

        public string Lastname { get; set; }
        [Required(ErrorMessage = "The Cedula is required")]

        public string Cedula { get; set; }
        [Required(ErrorMessage = "The Name is required")]

        public string Phone { get; set; }
        public string UserImg { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        [Required(ErrorMessage = "The CV is required")]

        public string Cv { get; set; }
        [Required(ErrorMessage = "The Birth Date is required")]

        public DateTime BirthDate { get; set; }
    }
}
