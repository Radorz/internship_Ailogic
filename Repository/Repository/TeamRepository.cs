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
    public class TeamRepository : RepositoryBase<Team, bnbar022dce4hrtds2xdContext>

    {
        private readonly IMapper _mapper;
        public TeamRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper) :base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<TeamDTO>> GetAllCustom()
        {
            var list = await GetAll();
            var lisdto = new List<TeamDTO>();
            foreach(var i in list)
            {
                var result = _mapper.Map<TeamDTO>(i);
                lisdto.Add(result);
            }

            return lisdto;


        }
        public async Task<TeamDTO> GetByIdCustom(int id)
        {
            var list = await GetbyId(id);
            var result = _mapper.Map<TeamDTO>(list); 

            return result;


        }
        public async Task<TeamDTO> AddCustom(TeamDTOPost dto)
        {
            var li = _mapper.Map<Team>(dto);
            var added = await Add(li);
            var result = _mapper.Map<TeamDTO>(added);

            return result;


        }

        public async Task<TeamDTO> updateCustom(int id, TeamDTOPost dto)
        {
            var team = await GetbyId(id);
            team.IdInternship = dto.IdInternship;
            team.Name = dto.Name;
            var result = await Update(team);
            TeamDTO returns = _mapper.Map<TeamDTO>(result);
            return returns;



        }

    }
}
