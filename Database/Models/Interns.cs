﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Database.Models
{
    public partial class Interns
    {
        public int IdInternt { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string IdUser { get; set; }
        public string Cedula { get; set; }
        public string Phone { get; set; }
        public string UserImg { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        public string Cv { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
