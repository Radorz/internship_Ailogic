using AutoMapper;
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
    public class InternTeamRepository : RepositoryBase<InternTeam, bnbar022dce4hrtds2xdContext>

    {
        private readonly IMapper _mapper;

        public InternTeamRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper) :base(context)
        {
            _mapper = mapper;
        }

        public async Task<bool> addInternToTeam(InternTeamDTO dto)
        {

            var li = _mapper.Map<InternTeam>(dto);
            await Add(li);
            return true;

        }

        public async Task<bool> deleteInternToTeam(int idintern)
        {

            var li = _context.InternTeam.FirstOrDefault(a => a.IdInternt == idintern);
            _context.Set<InternTeam>().Remove(li);
            await _context.SaveChangesAsync();
            return true;

        }

    }
}
