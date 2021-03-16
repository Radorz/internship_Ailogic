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
    public class AssignmentsRepository : RepositoryBase<Assignments, bnbar022dce4hrtds2xdContext>
    {
        private readonly IMapper _mapper;
        public AssignmentsRepository(bnbar022dce4hrtds2xdContext context,
                                     IMapper mapper )
            : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<AssignmentsDTO>> GetAllCustom()
        {
            List<AssignmentsDTO> assignmentList = new List<AssignmentsDTO>();
            var assignments = await _context.Set<Assignments>().ToListAsync();
            foreach (var i in assignments)
            {

                var assignmet = _mapper.Map<AssignmentsDTO>(i);
                assignmet.IdInternship = i.Id_Internship;
                var internship = await _context.Internship.FirstOrDefaultAsync(x => x.IdInternship == i.Id_Internship);
                assignmet.Internship = _mapper.Map<InternshipsDTO>(internship);
                assignmentList.Add(assignmet);

            }

            return assignmentList;
        }
    
    }
}
