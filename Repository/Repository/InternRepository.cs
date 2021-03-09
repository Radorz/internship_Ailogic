using Database.Models;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Database.Models;

namespace Repository.Repository
{
    class InternRepository : RepositoryBase<Interns, bnbar022dce4hrtds2xdContext>
    {
        public InternRepository(bnbar022dce4hrtds2xdContext context) :base(context){}

        public async Task<bool> AddCustom(InternDTO dto)
        {

        }

    }
}
