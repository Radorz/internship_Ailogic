using System;
using System.Collections.Generic;


namespace Database.Models
{
    public partial class RequestInternship
    {
        public int IdRequestInternship { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Cedula { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        public string Cv { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdInternship { get; set; }

    }
}
