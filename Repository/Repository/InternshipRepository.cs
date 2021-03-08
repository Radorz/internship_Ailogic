using Database.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class InternshipRepository : RepositoryBase<Internship, bnbar022dce4hrtds2xdContext>
    {
        public InternshipRepository(bnbar022dce4hrtds2xdContext context) : base(context)
        {

        }
      
    }
}
