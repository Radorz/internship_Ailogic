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
    public class RequestInternshipRepository : RepositoryBase<RequestInternship, bnbar022dce4hrtds2xdContext>
    {
        public RequestInternshipRepository(bnbar022dce4hrtds2xdContext context) : base(context)
        {

        }
        //public async Task<bool> Apply(ApplyInternshipDTO dto)
        //{
            

        //}

       
    }
}
