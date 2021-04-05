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
        [EmailAddress(ErrorMessage = "The Email is no valid")]
        [Required(ErrorMessage = "The Email is required")]
        public string EmailUser { get; set; }
        [Required(ErrorMessage = "The Id of Assigment is required")]
        public int id_assignments { get; set; }
        [Required(ErrorMessage = "The File is required")]
        [FromForm]
        public IFormFile File { get; set; }


       
    }
}
