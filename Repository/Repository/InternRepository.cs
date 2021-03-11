using Database.Models;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Repository.Repository
{
    public class InternRepository : RepositoryBase<Interns, bnbar022dce4hrtds2xdContext>
    {

        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public InternRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper, UserManager<IdentityUser> userManager) :base(context)
        {
            this._mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Interns> AddCustom(InternCreationDTO dto)
        {
          
            var Intern = _mapper.Map<Interns>(dto);
            Intern.IdUser = "7db4a185-b351-45f3-a2b4-ca939897c6ec";
            try
            {
                await _context.Set<Interns>().AddAsync(Intern);
                await _context.SaveChangesAsync();
                return Intern;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<InternDTO>> GetAllCustom()
        {
            List<InternDTO> InternList = new List<InternDTO>();
            var interns = await _context.Set<Interns>().ToListAsync();

            foreach (var i in interns)
            {

                var intern = _mapper.Map<InternDTO>(i);
                intern.IdUser = i.IdUser;
                var user = await _userManager.FindByIdAsync(i.IdUser);
                var internReturn = new UserDTO();
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
            
            var user = await _userManager.FindByIdAsync(internDTO.IdUser);
            var internReturn = new UserDTO();
            internReturn.Email = user.Email;
            internReturn.PhoneNumber = user.PhoneNumber;
            internDTO.User = internReturn;
            return internDTO;
        }

        public async Task<bool> UpdateCustom(int id, InternCreationDTO dto)
        {
            var intern = await _context.Set<Interns>().FindAsync(id);
            if (intern == null)
            {
                return false;
            }

            try
            {
                //intern = _mapper.Map<Interns>(dto);
                intern.IdInternt = id;
               
                intern.Name = dto.Name;
                intern.Lastname = dto.Lastname;
                intern.IdUser = "7db4a185-b351-45f3-a2b4-ca939897c6ec";
                intern.Cedula = dto.Cedula;
                intern.Phone = dto.Phone;
                intern.UserImg = dto.UserImg;
                intern.Github = dto.Github;
                intern.Linkedin = dto.Linkedin;
                intern.Cv = dto.Cv;
                intern.BirthDate = dto.BirthDate;
                intern.IdInternt = id;
                _context.Entry(intern).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                
                return false;
            }
            


            
        } 

    }
}
