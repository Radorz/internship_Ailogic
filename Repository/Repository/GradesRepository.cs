using AutoMapper;
using Database.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GradesRepository : RepositoryBase<Grades, bnbar022dce4hrtds2xdContext>
    {

        private readonly IMapper _mapper;

        public GradesRepository(bnbar022dce4hrtds2xdContext context,
            IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }


        public async Task<List<GradesDTO>> GetAllCustom()
        {
            List<GradesDTO> gradesDTOs = new List<GradesDTO>();
            var Grades = await _context.Set<Grades>().ToListAsync();
            foreach (var item in Grades)
            {
                var grade = _mapper.Map<GradesDTO>(item);
                gradesDTOs.Add(grade);

            }
            return gradesDTOs;
        }

        public async Task<GradesDTO> GetByIdCustom(int id)
        {
            var grades = await _context.Set<Grades>().FirstOrDefaultAsync(x => x.id_grades == id);
            var gradesDTO = _mapper.Map<GradesDTO>(grades);
            return gradesDTO;
        }

        public async Task<bool> AddCustom (GradesCreationDTO gradesCreation)
        {

        }

    }
}
