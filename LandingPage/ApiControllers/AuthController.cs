using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Database.Models;
using DTO;
using Repository.Repository;
using internship_Ailogic.Helpers;

namespace LandingPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly Utilities _utilities;


        public AuthController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            RequestInternshipRepository requestInternshipDTO,
            Utilities utilities)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _utilities = utilities;
        }


        [HttpPost("create")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                List<string> role = new List<string>();
                role.Add("Intern");
                return _utilities.BuildToken(model, role);
            }
            else
            {
                return BadRequest("Username or password invalid");
            }
        }

        [HttpGet]
        public string Get()
        {
            return "Hola";
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)

        {  if (ModelState.IsValid)
            {
                var find = await _userManager.FindByEmailAsync(userInfo.Email);
                if (find != null) {
                    var result = await _signInManager.PasswordSignInAsync(find.UserName, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(userInfo.Email);
                        var roles = await _userManager.GetRolesAsync(user);
                        return _utilities.BuildToken(userInfo, roles);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return BadRequest(ModelState);
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }

            }
            else
            {
                return BadRequest(ModelState);

            }
        }

       



      
    }

}
