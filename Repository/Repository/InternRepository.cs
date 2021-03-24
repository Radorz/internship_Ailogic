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
using EmailHandler;

namespace Repository.Repository
{
    public class InternRepository : RepositoryBase<Interns, bnbar022dce4hrtds2xdContext>
    {

        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Iemailsender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InternRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper, 
            UserManager<IdentityUser> userManager, Iemailsender iemailsender, RoleManager<IdentityRole> roleManager) :base(context)
        {
            this._mapper = mapper;
            _userManager = userManager;
            _emailSender = iemailsender;
            _roleManager = roleManager;
        }

        public async Task<InternDTO> AddCustom(ApplyInternshipDTOPost dto, string password)
        {
            // Crear usuario
            var user = new IdentityUser { UserName = dto.Email, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, password);
            // Buscar usuario. Si se encuentra seguimos la ejecucion
            if (!result.Succeeded)
            {
                return null;
            }

            var CreatedUser = await _userManager.FindByEmailAsync(dto.Email);
            var Intern = _mapper.Map<Interns>(dto);
            // Mensaje a enviar por correo
            var message = new Message(new string[] { dto.Email }, "Informacion Pasantias AILogic",
             "Felicidades " + dto.Name + " " + dto.Lastname + @" ha sido seleccionado para participar en nuestra gran pasantia. Para iniciar sesion en la plataforma primero visite
             este espacio para configurar su cuenta: https://frontend-pasantes.vercel.app/recuperar-clave" + "/" + CreatedUser.Id + "Su usuario es su mismo correo");
            await _emailSender.SendMailAsync(message);
            Intern.IdUser = CreatedUser.Id;
            try { 

            var internship = await _context.Internship.FirstOrDefaultAsync(a => a.Status == "En Convocatoria");
            Intern.IdIntership = internship.IdInternship;
            await _userManager.AddToRoleAsync(CreatedUser, "Intern");
            await _context.Set<Interns>().AddAsync(Intern);
            await _context.SaveChangesAsync();
            return await GetByIdCustom(Intern.IdInternt);
        }
            catch
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
           
            internDTO.User = internReturn;
            return internDTO;
        }
        public async Task<InternDTO> GetByIdUserCustom(string id)
        {
            var intern = await _context.Set<Interns>().FirstOrDefaultAsync(x => x.IdUser==id);
            var internDTO = _mapper.Map<InternDTO>(intern);

            var user = await _userManager.FindByIdAsync(internDTO.IdUser);
            var internReturn = new UserDTO();
            internReturn.Email = user.Email;

            internDTO.User = internReturn;
            return internDTO;
        }

        //public async Task<InternDTO> GetByIdUserbyintershipCustom(string id)
        //{
        //    var intern = await _context.Set<Interns>().FirstOrDefaultAsync(x => x. == id);
        //    var internDTO = _mapper.Map<InternDTO>(intern);

        //    var user = await _userManager.FindByIdAsync(internDTO.IdUser);
        //    var internReturn = new UserDTO();
        //    internReturn.Email = user.Email;

        //    internDTO.User = internReturn;
        //    return internDTO;
        //}
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
                intern.Cedula = dto.Cedula;
                intern.Phone = dto.Phone;
                intern.UserImg = dto.UserImg;
                intern.Github = dto.Github;
                intern.Linkedin = dto.Linkedin;
                intern.Cv = dto.Cv;
                intern.BirthDate = DateTime.Parse(dto.BirthDate);
                intern.IdInternt = id;
                _context.Entry(intern).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                return false;
            }
           
        } 

        public async Task<bool> linkresetemail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);    
            if (user == null)
            {
                return false;
            }
            try
            {
                var message = new Message(new string[] { email }, "Cambio de contraseña Pasantias AILogic",
                    "Hemos sidos notificados de que ha perdido su contraseña, dirigase el link siguiente parea recuperar su cuenta " +
                  "https://frontend-pasantes.vercel.app/recuperar-clave" + "/" + user.Id);
                await _emailSender.SendMailAsync(message);
                return true;

            }
            catch(Exception e)
            {
                return false;

            }
        }

        public async Task<bool> deletedCustom(int id)
        {


            var intern = await Delete(id);


            if (intern == null)
            {
                return false;

            }
            var user = await _userManager.FindByIdAsync(intern.IdUser);
            if (user ==null)
            {
                return false;

            }
          await  _userManager.DeleteAsync(user);
          var files = await _context.Files.Where(x => x.IdUser == intern.IdUser).ToListAsync();

            foreach( var i in files)
            {
                _context.Set<Files>().Remove(i);
            }
            await _context.SaveChangesAsync();
            return true;




        }


    }
}
