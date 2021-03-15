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

        public RolesController(bnbar022dce4hrtds2xdContext context,
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
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



    }
}
