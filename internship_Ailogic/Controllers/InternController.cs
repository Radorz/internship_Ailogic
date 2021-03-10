
using DTO;
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
    public class InternController :ControllerBase
    {
        private readonly InternRepository _internRepository;

        public InternController(InternRepository internRepository)
        {
            this._internRepository = internRepository;
        }

        [HttpGet]
        public async Task<List<InternDTO>> Get()
        {

            return await _internRepository.GetAllCustom();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InternDTO>> Get(int id)
        {
            return await _internRepository.GetByIdCustom(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(InternDTO dto)
        {
            if(await _internRepository.AddCustom(dto))
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InternDTO>> Put(int id, InternDTO dto)
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
            var intern = _internRepository.Delete(id);
            if (intern != null)
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
