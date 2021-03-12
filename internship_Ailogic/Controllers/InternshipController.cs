﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Repository;
using Repository.Repository;
using Database.Models;

namespace internship_Ailogic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return await _internshipsRepository.GetByIdCustom(id);
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

            await _internshipsRepository.UpdateCustom(id, dto);
            if (ModelState.IsValid)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("No se ha podido actualizar");
            }


        }
        AcceptVerbs("GET", "POST")]
public IActionResult VerifyName(string firstName, string lastName)
        {
            if (!_userService.VerifyName(firstName, lastName))
            {
                return Json($"A user named {firstName} {lastName} already exists.");
            }

            return Json(true);
        }

    }
}
