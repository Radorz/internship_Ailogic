using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Database.Models
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
        }

        public int IdQuestion { get; set; }
        public int IdEvaluation { get; set; }
        public string Question { get; set; }

        public virtual Evaluations IdEvaluationNavigation { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
    }
}
