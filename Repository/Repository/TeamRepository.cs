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
        private readonly InternRepository _internRepository;

        public TeamRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper, InternRepository internRepository) :base(context)
        {
            _mapper = mapper;
            _internRepository = internRepository;
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
        public Task<List<TeamDTO>> GetByIntershipCustom(int id)
        {
            var list =  _context.Team.Where(a => a.IdInternship== id).ToList();

            var listdto = new List<TeamDTO>();
            foreach(var i in list)
            {

                var result = _mapper.Map<TeamDTO>(i);
                listdto.Add(result);

            }


            return Task.FromResult(listdto);


        }

        public async Task<List<InternDTO>> GetInternsByteam(int id)
        {
            var list = _context.InternTeam.Where(a => a.IdTeam == id);
            var listinterns = new List<InternDTO>();
            foreach(var i in list)
            {
                var intern = await _internRepository.GetByIdCustom(id);
                if(intern != null)
                {
                    listinterns.Add(intern);
                }

            }

            return listinterns;


        }
        public async Task<TeamDTO> AddCustom(TeamDTOPost dto)
        {
            var li = _mapper.Map<Team>(dto);
            var added = await Add(li);
            var result = _mapper.Map<TeamDTO>(added);

            return result;


        }

        public async Task<bool> AddInternToTeam(InternTeamDTO dto)
        {
            var li = _mapper.Map<InternTeam>(dto);
            _context.Set<InternTeam>().Add(li);
            await _context.SaveChangesAsync();

            return true;


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
