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
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionsRepository _questionsRepository;
        public QuestionsController(QuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<QuestionsDTO>>> Get()
        {
            return await _questionsRepository.GetAllCustom();
        }

        [HttpGet("{id}", Name = "GetQuestions")]
        public async Task<ActionResult<QuestionsDTO>> Get(int id)
        {
            return await _questionsRepository.GetByIdCustom(id);
        }


        [HttpPost]
        public async Task<ActionResult> Post(QuestionsDTOPost dto)
        {
            var assignment = await _questionsRepository.AddCustom(dto);
            if (assignment != null)
            {

                return Ok(assignment);

            }
            else
            {
                return BadRequest("No se ha podido crear");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QuestionsDTOPost>> Put(int id, QuestionsDTOPost dto)
        {
            if (id != dto.IdQuestion)
            {
                return BadRequest("Is not the same id");
            }

            if (await _questionsRepository.UpdateCustom(id, dto))
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
            var intern = await _questionsRepository.Delete(id);
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

