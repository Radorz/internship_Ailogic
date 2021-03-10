
using AutoMapper;
using Database.Models;
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

        private readonly IMapper _mapper;

        public InternController(InternRepository internRepository, IMapper mapper)
        {
            _internRepository = internRepository;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InternCreationDTO dto)
        {
            var intern = await _internRepository.AddCustom(dto);
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
            var intern = await _internRepository.Delete(id);
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
