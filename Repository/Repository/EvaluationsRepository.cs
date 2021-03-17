using Database.Models;
using DTO;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class EvaluationsRepository : RepositoryBase<Evaluations, bnbar022dce4hrtds2xdContext>
    {
        public EvaluationsRepository(bnbar022dce4hrtds2xdContext context) :base(context)
        {
                    
        }

        //public async Task<EvaluationsDTO> GetAllCustom()
        //{

        //}

    }
}
