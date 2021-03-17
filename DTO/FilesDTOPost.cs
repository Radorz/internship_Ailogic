using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FilesDTOPost
    {
        [Required(ErrorMessage = "The ID of the User is required")]

        public int IdUser { get; set; }
        [Required(ErrorMessage = "The FileName is required")]

        public string FileName { get; set; }
        [Required(ErrorMessage = "The Path is required")]

        public string Path { get; set; }
    }
}
