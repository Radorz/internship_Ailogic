using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ApplyInternshipDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Cedula { get; set; }
        public int Phone { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        public string Cv { get; set; }
        public DateTime BirthDate { get; set; }
        [EmailAddress(ErrorMessage = "The Email is no valid")]
        public string Email { get; set; }

    }
}
