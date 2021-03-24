using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace Repository.Repository
{
    public class InternshipsRepository : RepositoryBase<Internship, bnbar022dce4hrtds2xdContext>
    {
        private readonly IMapper _mapper;

        public InternshipsRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        // This method get all information about table Internships.
        public async Task<List<InternshipsDTO>> GetAllCustom()
        {
            List<InternshipsDTO> InternshipList = new List<InternshipsDTO>();
            var internships = await _context.Set<Internship>().ToListAsync();
            foreach (var i in internships)
            {
                var internshipDTO = _mapper.Map<InternshipsDTO>(i);

                InternshipList.Add(internshipDTO);
            }
            return InternshipList;


        }
        public async Task<InternshipsDTO> GetByIdCustom(int id)
        {
            var internship = await _context.Set<Internship>().FindAsync(id);
            var internshipDTO = _mapper.Map<InternshipsDTO>(internship);

         
            return internshipDTO;
        }
       

        public async Task<bool> AddCustom(InternshipsDTOPost DTO)
        {
            var internship = new Internship();

            if (_context.Internship.FirstOrDefault(a => a.Status == "En Convocatoria") != null ||
                _context.Internship.FirstOrDefault(a => a.Status == "En Curso") != null)
            {
                internship.Status = "Inactiva";

            }
            else
            {
                internship.Status = "En Convocatoria";
            }

            internship.Name = DTO.Name;
            internship.Description = DTO.Description;
            internship.Initial_date = DateTime.Parse(DTO.Initial_date);
            internship.Final_date = DateTime.Parse(DTO.Final_date);
            internship.Intern_limit = DTO.Intern_limit;
            


            try
            {
                _context.Set<Internship>().Add(internship);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<ActionResult<InternshipsDTOPost>> UpdateCustom(int id, InternshipsDTOPost dto)
        {
            var internship = _context.Set<Internship>().Find(id);
            internship.Name = dto.Name;
            internship.Description = dto.Description;
            internship.Initial_date = DateTime.Parse(dto.Initial_date);
            internship.Final_date = DateTime.Parse(dto.Final_date);
            internship.Intern_limit = dto.Intern_limit;
            internship.Status = dto.Status;
            _context.Entry(internship).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return dto;
        }

     

    }
}
