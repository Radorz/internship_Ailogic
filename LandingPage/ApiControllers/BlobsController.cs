using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPage.ApiControllers
{
    [Route("api/blobs")]
    [ApiController]
    public class BlobsController : ControllerBase
    {
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;
        public BlobsController(IConfiguration configuration)
        {
            _azureConnectionString = configuration.GetValue<string>("AzureBlobStorageConnectionString");
            _azureContainerName = "filecontainer";
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blobs = new List<BlobDto>();
            var container = new BlobContainerClient(_azureConnectionString, _azureContainerName);
            await foreach (var blobItem in container.GetBlobsAsync())
            {
                var uri = container.Uri.AbsoluteUri;
                var name = blobItem.Name;
                var fullUri = uri + "/" + name;
                blobs.Add(new BlobDto { Name = name, Uri = fullUri, ContentType = blobItem.Properties.ContentType });
            }
            return Ok(blobs);
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
                    return Ok(blob.Uri.ToString());
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    } 
}
