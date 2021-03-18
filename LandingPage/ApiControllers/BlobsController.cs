﻿using Azure.Storage.Blobs;
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
    } 
}
