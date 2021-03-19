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
                assignmet.LimitDate = i.Limit_Date;
                assignmet.Id_Internship = i.Id_Internship;
                var internship = await _context.Internship.FirstOrDefaultAsync(x => x.IdInternship == i.Id_Internship);
                assignmet.Internship = _mapper.Map<InternshipsDTO>(internship);
                assignmentList.Add(assignmet);

            }

            return assignmentList;
        }

        public async Task<AssignmentsDTO> GetByIdCustom(int id)
        {
            var assignment = await _context.Set<Assignments>().FirstOrDefaultAsync(x => x.Id_Assignment == id);
            var assignmentDTO = _mapper.Map<AssignmentsDTO>(assignment);
            var internship = await _context.Internship.FirstOrDefaultAsync(x => x.IdInternship == assignmentDTO.Id_Internship);
            assignmentDTO.Internship = _mapper.Map<InternshipsDTO>(internship);
            return assignmentDTO;
        }

        public async Task<List<AssignmentsDTO>> GetByInternship(int idInternship)
        {
            List<AssignmentsDTO> assignmentsList = new List<AssignmentsDTO>();
            var assignments = _context.Assignments.Where(x => x.Id_Internship == idInternship).ToList();
            foreach (var i in assignments)
            {
                var assignmet = _mapper.Map<AssignmentsDTO>(i);
                assignmet.Id_Internship = i.Id_Internship;
                var internship = await _context.Internship.FirstOrDefaultAsync(x => x.IdInternship == i.Id_Internship);
                assignmet.Internship = _mapper.Map<InternshipsDTO>(internship);
                assignmentsList.Add(assignmet);
            }
            return assignmentsList;
        }

        public async Task<AssignmentsDTOPost> AddCustom(AssignmentsDTOPost dto)
        {
            var assignment = _mapper.Map<Assignments>(dto);
            try
            {
                await _context.Set<Assignments>().AddAsync(assignment);
                await _context.SaveChangesAsync();
                return dto;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }

        }

        public async Task<bool> UpdateCustom(int id, AssignmentsDTOPost dto)
        {
            var assignment = await _context.Set<Assignments>().FindAsync(id);
            if (assignment == null)
            {
                return false;
            }
            try
            {
                //intern = _mapper.Map<Interns>(dto);
                assignment.Id_Assignment = id;
                assignment.Id_Internship = dto.Id_Internship;
                assignment.Title = dto.Title;
                assignment.Description = dto.Description;
                assignment.Limit_Date = DateTime.Parse(dto.LimitDate);
                assignment.Modality = dto.Modality;
                _context.Entry(assignment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
