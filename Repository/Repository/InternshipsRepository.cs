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

namespace Repository.Repository
{
    public class InternshipsRepository : RepositoryBase<Internship, bnbar022dce4hrtds2xdContext>
    {
        public InternshipsRepository(bnbar022dce4hrtds2xdContext context) : base(context)
        {

        }

        // This method get all information about table Internships.
        public async Task<List<InternshipsDTO>> GetAllCustom()
        {
            List<InternshipsDTO> InternshipList = new List<InternshipsDTO>();
            var internships = await _context.Set<Internship>().ToListAsync();
            foreach (var i in internships)
            {
                var internship = new InternshipsDTO()
                {
                    Name = i.Name,
                    Description = i.Description,
                    Initial_date = i.Initial_date,
                    Final_date = i.Final_date,
                    Intern_limit = i.Intern_limit,
                    Status = i.Status
                };
                InternshipList.Add(internship);
            }
            return InternshipList;


        }

        public async Task<bool> AddCustom(InternshipsDTO DTO)
        {

            var internship = new Internship()
            {
                Name = DTO.Name,
                Description = DTO.Description,
                Initial_date = DTO.Initial_date,
                Final_date= DTO.Final_date,
                Intern_limit= DTO.Intern_limit,
                Status = DTO.Status
            };


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

        public async Task<ActionResult<InternshipsDTO>> UpdateCustom(int id, InternshipsDTO dto)
        {
            var internship = _context.Set<Internship>().Find(id);
            internship.Name = dto.Name;
            internship.Description = dto.Description;
            internship.Initial_date = dto.Initial_date;
            internship.Final_date = dto.Final_date;
            internship.Intern_limit = dto.Intern_limit;
            internship.Status = dto.Status;
            _context.Entry(internship).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return dto;



        }

     

    }
}
