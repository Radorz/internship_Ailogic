using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InternshipsDTOPost
    {


        [Required(ErrorMessage = "The name is required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "The description is required")]

        public string Description { get; set; }
        [Required(ErrorMessage = "The Initial Date is required")]

        public DateTime Initial_date { get; set; }
        [Required(ErrorMessage = "The Final Date is required")]

        public DateTime Final_date { get; set; }
        [Required(ErrorMessage = "The Limit of interns is required")]

        public int Intern_limit { get; set; }
        public bool Status { get; set; }
    }

}