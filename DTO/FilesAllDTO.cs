﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class FilesAllDTO
    {
        public int IdFiles { get; set; }
        public string IdUser { get; set; }
        public InternDTO Intern { get; set; }
        public int IdAssignment { get; set; }
        public AssignmentsDTO Assignments { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}