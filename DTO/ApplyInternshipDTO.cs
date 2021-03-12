﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DTO
{
    public class ApplyInternshipDTO
    {
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The LastName is required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "The Cedula is required")]
        [RegularExpression(@"[0-9]{3}-?\d{7}-?\d{1}", ErrorMessage = "The cedula must contain 11 digits and 2 -")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "The Phone is required")]
        [RegularExpression(@"[0-9]{3}-?\d{3}-?\d{4}", ErrorMessage = "The Phone Number must contain 10 digits and 2 -")]
        public string Phone { get; set; }

        public string Github { get; set; }
        public string Linkedin { get; set; }
        public string Cv { get; set; }
        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "The Email is no valid")]
        [Required(ErrorMessage = "The Email is required")]
       
        public string Email { get; set; }



    }
}
