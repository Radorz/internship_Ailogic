using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AssignmentsDTOUpdate
    {

        public int Id_Assignment { get; set; }
        public int Id_Internship { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; }
        public string LimitDate { get; set; }
        public string Modality { get; set; }
    }
}
