using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPage.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        private readonly EvaluationsRepository _evaluationsRepository;

        public EvaluationsController(EvaluationsRepository evaluationsRepository)
        {
            _evaluationsRepository = evaluationsRepository;
        }


        [HttpGet]

        public async Task<IEnumerable<EvaluationsDTO>> Get()
        {
            return await _evaluationsRepository.GetAllCustom();
        }


        [HttpGet("{id}")]
        public async Task<EvaluationsDTO> Get(int id)
        {
            return await _evaluationsRepository.GetByIdCustom(id);
        }

       [HttpPost]
       public async Task<ActionResult<EvaluationsDTO>> Post([FromBody] EvaluationsDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _evaluationsRepository.AddCustom(dto);
                return Ok(dto);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<EvaluationsDTO>> Put(int id, [FromBody] EvaluationsDTO dto)
        {
            if (ModelState.IsValid)
            {
                var evaluation = await _evaluationsRepository.UpdateCustom(id, dto);
                return Ok(evaluation);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           if(await _evaluationsRepository.Delete(id) != null)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
