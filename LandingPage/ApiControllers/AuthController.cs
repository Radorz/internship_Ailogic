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
using System.ComponentModel.DataAnnotations;

namespace LandingPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly Utilities _utilities;
        private readonly InternRepository _internRepository;



        public AuthController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            RequestInternshipRepository requestInternshipDTO,
            Utilities utilities,
            InternRepository internRepository
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _utilities = utilities;
            _internRepository = internRepository;
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

        [HttpPost("resetpassword/{id}")]
        public async Task<ActionResult> resetpassword(string id, resetpassword dto)
        {
            try
            {
                var useridentity = await _userManager.FindByIdAsync(id);
                var token = await _userManager.GeneratePasswordResetTokenAsync(useridentity);
                await _userManager.ResetPasswordAsync(useridentity, token, dto.Password);

                return Ok("Successful");
            }
            catch ( Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }

        [HttpPost("linkchangepassword")]
        public async Task<ActionResult> linkchangepassword([EmailAddress(ErrorMessage = "The Email is no valid")]
                                                             string email)
        {
            try
            {
                if(await _internRepository.linkresetemail(email))
                {

                    return Ok("Successful");

                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }


    }

}
