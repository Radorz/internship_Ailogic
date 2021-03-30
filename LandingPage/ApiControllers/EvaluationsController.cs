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
        public async Task<ActionResult<EvaluationsDTO>> Get(int id)
        {
            try
            {
                var resul = await _evaluationsRepository.GetByIdCustom(id);
                if (resul == null)
                {
                    return NotFound();
                }
                return resul;
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

       [HttpPost]
       public async Task<ActionResult<EvaluationsDTO>> Post([FromBody] EvaluationsDTOPost dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _evaluationsRepository.AddCustom(dto);
                    return Ok(dto);
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"Internal server error: {e}");

                }
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
                try {
                    if (id != dto.IdEvaluation)
                    {
                        return BadRequest("Use the same ID");
                    }
                    var evaluation = await _evaluationsRepository.UpdateCustom(id, dto);
                    if (evaluation == null)
                    {
                        return NotFound();
                    }
                    return Ok(evaluation);
                } catch ( Exception e)
                {
                    return StatusCode(500, $"Internal server error: {e}");
                }
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (await _evaluationsRepository.Delete(id) != null)
                {
                    return Ok("Deleted Successfully");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
