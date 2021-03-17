using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO
{
    public partial class TeamDTO
    {
        public int IdTeam { get; set; }
        public int IdInternship { get; set; }
        public string Name { get; set; }
    }
}
