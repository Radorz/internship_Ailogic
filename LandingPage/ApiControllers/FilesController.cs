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
    public class FilesController : ControllerBase
    {
        private readonly FilesRepository _filesRepository;

        public  FilesController (FilesRepository filesRepository)
        {
            _filesRepository = filesRepository;



        }
        [HttpGet(("{id}"), Name = "GetFile")]
        public async Task<ActionResult<FilesDTO>> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var file = await _filesRepository.getByIdCustom(id);
                if (file !=null)
                {
                    return file;
                }
                return NotFound();
            }

            return BadRequest();

        }

        [HttpPost]
        public async Task<ActionResult<FilesDTO>> Add(FilesDTOPost dto)
        {
            if (ModelState.IsValid)
            {
                var file = await _filesRepository.addCustom(dto);
                if (file != null)
                {
                    return new CreatedAtRouteResult("GetFile", new { id = file.IdFiles }, file);
                }
                return NotFound();
            }

            return BadRequest();

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<FilesDTO>> Update(int id, FilesDTOPost dto)
        {
            if (ModelState.IsValid)
            {
                var file = await _filesRepository.updateCustom(id,dto);
                if (file != null)
                {
                    return  Ok(file);
                }
                return NotFound();
            }

            return BadRequest();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var file = await _filesRepository.Delete(id);
                if (file != null)
                {
                    return Ok();
                }
                return NotFound();
            }

            return BadRequest();

        }


    }
}
