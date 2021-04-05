using DTO;
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
    public class TeamController : ControllerBase
    {
        private readonly TeamRepository _teamRepository;

        public TeamController(TeamRepository teamRepository)
        {

            _teamRepository = teamRepository;
        }

        // GET: api/<TeamController>
        [HttpGet]
        public async Task<List<TeamDTO>> Get()
        {
            return await _teamRepository.GetAllCustom();
        }


        // GET api/<TeamController>/5
        [HttpGet("{id}", Name = "GetTeam")]
        public async Task<TeamDTO> Get(int id)
        {
            return await _teamRepository.GetByIdCustom(id);
        }

        // GET api/<TeamController>/5
        [HttpGet("GetByInternship/{id}")]
        public async Task<List<TeamDTO>> GetByInternship(int id)
        {
            return await _teamRepository.GetByIntershipCustom(id);
        }

        // GET api/<TeamController>/5
        [HttpGet("GetInternsByTeam/{id}")]
        public async Task<List<InternDTO>> GetInternsByTeam(int id)
        {
            return await _teamRepository.GetInternsByteam(id);
        }

        // POST api/<TeamController>
        [HttpPost]
        public async Task<ActionResult<TeamDTO>> Add(TeamDTOPost dto)
        {
            if (ModelState.IsValid)
            {
                var team = await _teamRepository.AddCustom(dto);
                if (team != null)
                {
                    return new CreatedAtRouteResult("GetTeam", new { id = team.IdTeam }, team);
                }
                return NotFound();
            }

            return BadRequest();

        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TeamDTO>> Put(int id, [FromBody] TeamDTOPost dto)
        {
            if (ModelState.IsValid)
            {
                var team = await _teamRepository.updateCustom(id, dto);
                if (team != null)
                {
                    return Ok(team);
                }
                return NotFound();
            }

            return BadRequest();
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var team = await _teamRepository.Delete(id);
                if (team != null)
                {
                    return Ok();
                }
                return NotFound();
            }

            return BadRequest();

        }
    }
}
