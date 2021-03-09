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
    public class InternshipsRepository : RepositoryBase<Internship, bp6pznqoywrjk82ucfnmContext>
    {
        public InternshipsRepository(bp6pznqoywrjk82ucfnmContext context) : base(context)
        {

        }

        // This method get all information about table Internships.
        public async Task<List<InternshipsDTO>> GetAllCustom()
        {
            List<InternshipsDTO> InternshipList = new List<InternshipsDTO>();
            var internships = _context.Set<Internship>().ToList();
            foreach (var i in internships)
            {
                var internship = new InternshipsDTO()
                {
                    Name = i.Name,
                    Description = i.Description,
                    Date = i.Date,
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
                Date = DTO.Date,
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
            internship.Date = dto.Date;
            internship.Status = dto.Status;
            _context.Entry(internship).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return dto;



        }

     

    }
}
