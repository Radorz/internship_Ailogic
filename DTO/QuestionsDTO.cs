using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuestionsDTO
    {
        public int IdQuestion { get; set; }
        public int IdEvaluation { get; set; }
        public EvaluationsDTO Evaluations { get; set; }
        public string Question { get; set; }
    }
}
