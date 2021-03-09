using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Database.Models
{
    public partial class Evaluations
    {
        public Evaluations()
        {
            Questions = new HashSet<Questions>();
            Results = new HashSet<Results>();
        }

        public int IdEvaluation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<Results> Results { get; set; }
    }
}
