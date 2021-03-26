﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Database.Models
{
    public partial class Files
    {
        public int IdFiles { get; set; }
        public string IdUser { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
