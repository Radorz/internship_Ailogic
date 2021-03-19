using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public string EmailUser { get; set; }
        [Required(ErrorMessage = "The FileName is required")]
        [FromForm]
        public IFormFile File { get; set; }
       
    }
}
