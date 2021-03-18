using DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPage.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FilesRepository _filesRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FilesController (FilesRepository filesRepository, IWebHostEnvironment hostingEnvironment)
        {
            _filesRepository = filesRepository;
            _hostingEnvironment = hostingEnvironment;


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

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<FilesDTO>> Add()
        {
            try
            {
               
                var file = Request.Form.Files[0];
                var pathToSave = Path.Combine("Resources/Images"); ;
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, fileName.ToString());  
                    var dbPath = Path.Combine(pathToSave, fileName.ToString());
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
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
