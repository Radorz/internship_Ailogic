﻿using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {


        private readonly RequestInternshipRepository _requestInternshiprepo;

        public RequestController(RequestInternshipRepository requestInternshiprepo)
        {
            _requestInternshiprepo = requestInternshiprepo;

        }

        [HttpGet]
        public async Task<List<ApplyInternshipDTO>> Get()
        {

            return await _requestInternshiprepo.getlist();


        }


        [HttpPost("apply")]
        public async Task<ActionResult> Apply(ApplyInternshipDTOPost userInfo)
        {

            if (ModelState.IsValid)
            {
                var validation = await _requestInternshiprepo.ifExistRequest(userInfo);
                if (validation)
                {
                    var response = await _requestInternshiprepo.Apply(userInfo);
                    if (response)
                    {
                        return StatusCode(201);
                    }
                    else
                    {
                        return BadRequest("There are no active internships");
                    }
                }
                else
                {
                    return BadRequest("There are active Request or intern with this information");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var request = await _requestInternshiprepo.Delete(id); 
            if (request != null)
            {
                return Ok("Deleted Successfully.");
            }
            else
            {
                return NotFound("Could not delete :c");
            }

        }


    }
}
