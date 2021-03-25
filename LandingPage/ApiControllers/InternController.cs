
using AutoMapper;
using Database.Models;
using DTO;
using internship_Ailogic.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace LandingPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class InternController :ControllerBase
    {
        private readonly InternRepository _internRepository;
        private readonly IMapper _mapper;
        private readonly Utilities _utilities;
        private readonly UserManager<IdentityUser> _userManager;


        public InternController(InternRepository internRepository,
            IMapper mapper,
            Utilities utilities,
            UserManager<IdentityUser> userManager)
        {
            _internRepository = internRepository;
            _mapper = mapper;
            _utilities = utilities;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<List<InternDTO>> Get()
        {
            return await _internRepository.GetAllCustom();
        }

        [HttpGet("{id}", Name = "GetIntern")]
        public async Task<ActionResult<InternDTO>> Get(int id)
        {
            return await _internRepository.GetByIdCustom(id);
        }

        [HttpGet("GetInternbyinternship/{id}")]
        public async Task<ActionResult<List<InternDTO>>> Getbyinternship(int id)
        {
            return await _internRepository.GetInternbyintershipCustom(id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Intern")]
        [HttpGet("GetInternbyEmail/{Email}")]
        public async Task<ActionResult<InternDTO>> Getbyinternship([EmailAddress] string Email)
        {
            return await _internRepository.GetByEmailIntern(Email);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateinterntDTO dto)
        {
            if(await _userManager.FindByEmailAsync(dto.Email) != null)
            {
                return BadRequest("This email is already in use");
            }
            var password = _utilities.CreatePassword(dto.Name, dto.Lastname, dto.Cedula, dto.BirthDate);
            var intern = await _internRepository.AddCustom(dto,  password);
            if (intern != null)
            {
                var internDTO = _mapper.Map<InternDTO>(intern);
                return new CreatedAtRouteResult("GetIntern", new { id = intern.IdInternt }, internDTO);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InternDTO>> Put(int id, InternCreationDTO dto)
        {
            

            if(await _internRepository.UpdateCustom(id, dto))
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest("No se ha podido Modificar");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var intern = await _internRepository.deletedCustom(id);
            if (intern)
            {
                return Ok("Se ha borrado Correctamente");
            }
            else
            {
                return NotFound();
            }
        }

        

    }
}
