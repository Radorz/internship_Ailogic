using Database.Models;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Database.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class InternRepository : RepositoryBase<Interns, bnbar022dce4hrtds2xdContext>
    {

        private readonly IMapper _mapper;
        public InternRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper) :base(context)
        {
            this._mapper = mapper;
        }

        public async Task<bool> AddCustom(InternDTO dto)
        {
            var Intern = new Interns();
            Intern = _mapper.Map<Interns>(dto);
            try
            {
                await _context.Set<Interns>().AddAsync(Intern);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<InternDTO>> GetAllCustom()
        {
            List<InternDTO> InternList = new List<InternDTO>();
            var interns = await _context.Set<Interns>().ToListAsync();
            
            foreach (var i in interns)
            {

                var intern = _mapper.Map<InternDTO>(i);
                var user = await _context.AspNetUsers.FirstOrDefaultAsync(x => x.Id == i.IdUser);
                var internReturn = new UserDTO();
                internReturn.UserName = user.UserName;
                internReturn.Email = user.Email;
                internReturn.PhoneNumber = user.PhoneNumber;
                intern.User = internReturn;
                InternList.Add(intern);
                
            }
            return InternList;
        }

        public async Task<InternDTO> GetByIdCustom(int id)
        {
            var intern = await _context.Set<Interns>().FindAsync(id);
            var internDTO = _mapper.Map<InternDTO>(intern);
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(x => x.Id == internDTO.IdUser);
            var internReturn = new UserDTO();
            internReturn.UserName = user.UserName;
            internReturn.Email = user.Email;
            internReturn.PhoneNumber = user.PhoneNumber;
            internDTO.User = internReturn;




            return internDTO;


        }

        public async Task<bool> UpdateCustom(int id, InternDTO dto)
        {
            var intern = await _context.Set<Interns>().FirstOrDefaultAsync(x => x.IdInternt == id);
            intern = _mapper.Map<Interns>(dto);
            
            _context.Entry(intern).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;


            
        } 

    }
}
