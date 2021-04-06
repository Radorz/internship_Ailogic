using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Database.Models
{
    public partial class InternTeam
    {
        [Key]
        public int IdInternt { get; set; }
        public int IdTeam { get; set; }
    }
}
