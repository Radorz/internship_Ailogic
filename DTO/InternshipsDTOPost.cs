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

        [RegularExpression(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Wrong format for Initial_date YYYY-MM-DD")]
        [Required(ErrorMessage = "The Initial Date is required")]
        public string Initial_date { get; set; }

        [RegularExpression(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Wrong format for Initial_date YYYY-MM-DD")]
        [Required(ErrorMessage = "The Initial Date is required")]
        public string Final_date { get; set; }
        [Required(ErrorMessage = "The Limit of interns is required")]

        public int Intern_limit { get; set; }
        public string Status { get; set; }
    }

}