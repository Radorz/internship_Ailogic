using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Repository;

namespace internship_Ailogic.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly AssignmentsRepository _assignmentsRepository;
        public AssignmentsController(AssignmentsRepository assignmentsRepository)
        {
            _assignmentsRepository = assignmentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AssignmentsDTO>>> Get()
        {
            return await _assignmentsRepository.GetAllCustom();
        }

        [HttpGet("{id}", Name = "GetAssignment")]
        public async Task<ActionResult<AssignmentsDTO>> Get(int id)
        {
            return await _assignmentsRepository.GetByIdCustom(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssignmentsDTOPost dto)
        {
            var assignment = await _assignmentsRepository.AddCustom(dto);
            if (assignment != false)
            {
               
                return new CreatedAtRouteResult("GetIntern", new { id = dto.Id_Internship });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AssignmentsDTOPost>> Put(int id, AssignmentsDTOPost dto)
        {
            if (id != dto.Id_Assignment)
            {
                return BadRequest("Is not the same id");
            }

            if (await _assignmentsRepository.UpdateCustom(id, dto))
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
            var intern = await _assignmentsRepository.Delete(id);
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
