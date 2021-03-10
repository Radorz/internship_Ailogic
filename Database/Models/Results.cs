using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Database.Models
{
    public partial class Results
    {
        public int IdResult { get; set; }
        public int IdEvaluation { get; set; }
        public int IdIntern { get; set; }
    }
}
