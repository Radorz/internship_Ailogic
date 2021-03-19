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
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace LandingPage.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FilesRepository _filesRepository;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;
        public FilesController (FilesRepository filesRepository, IConfiguration configuration)
        {
            _filesRepository = filesRepository;
            _azureConnectionString = configuration.GetValue<string>("AzureBlobStorageConnectionString");
            _azureContainerName = "filecontainer";

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
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                if (file.Length > 0)
                {
                    var container = new BlobContainerClient(_azureConnectionString, _azureContainerName);
                    var createResponse = await container.CreateIfNotExistsAsync();
                    if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                        await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                    var blob = container.GetBlobClient(file.FileName);
                    await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                    using (var fileStream = file.OpenReadStream())
                    {
                        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                    }
                    FilesDTO filesDTO = new FilesDTO();
                    filesDTO.FileName = file.Name;
                    filesDTO.Path = blob.Uri.ToString();
                    return Ok(blob.Uri.ToString());
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        //[HttpPut("{id}")]
        //public async Task<ActionResult<FilesDTO>> Update(int id, FilesDTOPost dto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var file = await _filesRepository.updateCustom(id,dto);
        //        if (file != null)
        //        {
        //            return  Ok(file);
        //        }
        //        return NotFound();
        //    }

        //    return BadRequest();

        //}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var file = await _filesRepository.Delete(id);
        //        if (file != null)
        //        {
        //            return Ok();
        //        }
        //        return NotFound();
        //    }

        //    return BadRequest();

        //}


    }
}
