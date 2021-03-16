using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using System.Security.Claims;

namespace internship_Ailogic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly bnbar022dce4hrtds2xdContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(bnbar022dce4hrtds2xdContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this._roleManager = roleManager;
        }


        [HttpPost("AssignSecretaryRole")]
        public async Task<ActionResult> RoleAssignment(RolesDTO dto)
        {
            var usuario = await userManager.FindByIdAsync(dto.IdUser);
            if (usuario == null)
            {
                return NotFound();
            }
            await userManager.AddClaimAsync(usuario, new Claim(ClaimTypes.Role, dto.RoleName));
            await userManager.AddToRoleAsync(usuario, dto.RoleName);
            return Ok();
        }


        [HttpPost("updateRole/{id}")]
        public async Task<ActionResult> updaterole(string id, RolesDTO dto)
        {

            if (id != dto.IdUser)
            {
                return BadRequest("Is not the same id");
            }
            var usuario = await userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
           var rol = await userManager.GetRolesAsync(usuario);
            await userManager.RemoveClaimAsync(usuario, new Claim(ClaimTypes.Role, rol.First().ToString()));
            await userManager.RemoveFromRoleAsync(usuario, rol.First().ToString());
            await userManager.AddClaimAsync(usuario, new Claim(ClaimTypes.Role, dto.RoleName));
            await userManager.AddToRoleAsync(usuario, dto.RoleName);
            return Ok();
        }


<<<<<<< HEAD
        [HttpGet("{email}")]
        // This method retrieves a role of any user 
        public async Task<ActionResult> GetUserRole(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var roleName = await userManager.GetRolesAsync(user);


            //var roleName = context.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
            //var role = context.Roles.FirstOrDefault(x => x.Id == roleName.RoleId);
            return Ok(roleName.First().ToString());
        }
=======

>>>>>>> 33e042a2be50b5725364f322b5fff22dde1f394d
    }
}
