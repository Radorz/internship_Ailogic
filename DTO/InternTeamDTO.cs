using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DTO
{
    public partial class InternTeamDTO
    {
        [Required(ErrorMessage = "The IdInternt  is required")]
        public int IdInternt { get; set; }
        [Required(ErrorMessage = "The IdTeam  is required")]

        public int IdTeam { get; set; }
    }
}
