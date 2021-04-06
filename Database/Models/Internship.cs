using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Database.Models
{
    public partial class Internship
    {
        public int IdInternship { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Initial_date { get; set; }
        public DateTime Final_date { get; set; }
        public int Intern_limit { get; set; }
        public string Status { get; set; }
    }
}
