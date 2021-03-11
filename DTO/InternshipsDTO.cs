﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InternshipsDTO
    {

        public int IdInternship { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Initial_date { get; set; }
        public DateTime Final_date { get; set; }
        public int Intern_limit { get; set; }
        public bool Status { get; set; }
    }

}