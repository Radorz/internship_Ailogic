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
    public class FilesDTOdelete
    {
      

        [EmailAddress(ErrorMessage = "The Email is no valid")]
        [Required(ErrorMessage = "The Email is required")]
        public string EmailUser { get; set; }

        [Required(ErrorMessage = "The File is required")]
        public string FileName { get; set; }
       

    }
}
