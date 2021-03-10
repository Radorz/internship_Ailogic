using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internship_Ailogic.Controllers
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

        [HttpPost("apply")]
        public async Task<ActionResult> Apply(ApplyInternshipDTO userInfo)
        {

            if (ModelState.IsValid)
            {
                var response = await _requestInternshiprepo.Apply(userInfo);
                if (response)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
