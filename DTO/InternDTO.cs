﻿using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class InternDTO
    {
        public int IdInternt { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string IdUser { get; set; }
        public UserDTO User { get; set; }
        public string Cedula { get; set; }
        public string Phone { get; set; }
        public string UserImg { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        public string Cv { get; set; }
        public string BirthDate { get; set; }
    }
}
