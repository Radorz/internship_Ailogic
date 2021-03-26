using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Repository;
using Repository.Repository;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LandingPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class InternshipController : ControllerBase
    {

        private readonly InternshipsRepository _internshipsRepository;
        public InternshipController(InternshipsRepository internshipsRepository)
        {
            this._internshipsRepository = internshipsRepository;
        }

        [HttpGet]
        public async Task<List<InternshipsDTO>> Get()
        {
            return await _internshipsRepository.GetAllCustom();
        }

        [HttpGet("{id}", Name = "GetInternship")]
        public async Task<ActionResult<InternshipsDTO>> Get(int id)
        {
            var result = await _internshipsRepository.GetByIdCustom(id);
            if(result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Save(InternshipsDTOPost DTO)
        {
            if (ModelState.IsValid)
            {
               await _internshipsRepository.AddCustom(DTO);
                return Ok(DTO);
            }
            else
            {
                return BadRequest();
            }
            
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var internship =  await _internshipsRepository.Delete(id);
            if (internship != null)
            {
                return Ok("Se ha borrado correctamente");
            }
            else
            {
                return NotFound("No se ha podido borrar");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InternshipsDTO>> Update(int id, InternshipsDTOPost dto)
        {

            if (ModelState.IsValid)
            {
                await _internshipsRepository.UpdateCustom(id, dto);
                return StatusCode(201);
            }
            else
            {
                return BadRequest("No se ha podido actualizar");
            }


        }

        [HttpPatch("{idInternship}")]
        public async Task<ActionResult<InternshipsDTO>> UpdateStatus(int idInternship, string status)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var intership = await _internshipsRepository.GetByIdCustom(idInternship);
                    if (intership == null)
                    {
                        return NotFound("Internship not found");
                    }
                    await _internshipsRepository.UpdateStatus(idInternship, status);
                    return StatusCode(201);
                }
                else
                {
                    return BadRequest("No se ha podido actualizar");
                }
            }
            catch(Exception E)
            {
                return StatusCode(500);
            }


        }


    }
}
