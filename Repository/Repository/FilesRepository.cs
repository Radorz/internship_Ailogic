using Database.Models;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    class FilesRepository : RepositoryBase<Files, bnbar022dce4hrtds2xdContext>
    {
        private readonly bnbar022dce4hrtds2xdContext _context;
        public FilesRepository(bnbar022dce4hrtds2xdContext context)
            :base(context)
        {
            _context = context;
        }




    }
}
