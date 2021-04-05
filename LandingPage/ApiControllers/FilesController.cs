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
using Microsoft.AspNetCore.Identity;
//using Syncfusion.Presentation;
//using Syncfusion.PresentationToPdfConverter;
using Syncfusion.Office;
using Syncfusion.Presentation;
using Syncfusion.PresentationToPdfConverter;
using Syncfusion.Pdf;
//using Syncfusion.Pdf;
//using Syncfusion.Office;
//using Aspose.Slides;
//using Aspose.Slides.Export;
using System.Net.Http;

namespace LandingPage.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FilesRepository _filesRepository;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly InternRepository _internRepository;

        public FilesController (FilesRepository filesRepository, IConfiguration configuration, InternRepository internRepository, UserManager<IdentityUser> userManager)
        {
            _filesRepository = filesRepository;
            _azureConnectionString = configuration.GetValue<string>("AzureBlobStorageConnectionString");
            _azureContainerName = "filecontainer";
            _userManager = userManager;
            _internRepository = internRepository;

        }
        [HttpGet]
        public async Task<ActionResult<List<FilesDTO>>> Get()
        {
            if (ModelState.IsValid)
            {
                var file = await _filesRepository.getalla();
                if (file != null)
                {
                    return file;
                }
            }

            return NoContent();

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

        [HttpGet("assignments/{idAssignment}")]
        public async Task<ActionResult<List<FilesAllDTO>>> GetAssignmentAndFiles (int idAssignment)
        {
            if (ModelState.IsValid)
            {
                var file = await _filesRepository.GetFilesAll(idAssignment);
                if (file != null)
                {
                    return file;
                }
            }

            return NoContent();
            
        }

        [HttpPost]
        public async Task<IActionResult> Upload( [FromForm]FilesDTOPost DTO)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                if (file.Length > 0)
                {
                    // Instantiate a Presentation object that represents a PPT file
                    //Presentation presentation = new Presentation(file.OpenReadStream());

                    //// Save the presentation as PDF
                    //presentation.Save("PPT-to-PDF.pdf", SaveFormat.Pdf);
                    var uniqueName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var container = new BlobContainerClient(_azureConnectionString, _azureContainerName);
                    var createResponse = await container.CreateIfNotExistsAsync();
                    if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                        await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                    var blob = container.GetBlobClient(uniqueName);
                    await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                    using (var fileStream = file.OpenReadStream())
                    {
                        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                    }
                    FilesDTO filesDTO = new FilesDTO();
                    filesDTO.FileName = uniqueName;
                    var user = await _userManager.FindByEmailAsync(DTO.EmailUser);
                    filesDTO.IdUser = user.Id ;
                    filesDTO.IdAssignment = DTO.id_assignments;
                    filesDTO.Path = blob.Uri.ToString();

                   await _filesRepository.addCustom(filesDTO);
                    
                    return Ok(blob.Uri.ToString());
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete("{idfile}")]
        public async Task<IActionResult> Delete(int idfile, FilesDTOdelete dto)
        {
            try
            {
                if (await _filesRepository.Delete(idfile)==null)
                {


                }
                var container = new BlobContainerClient(_azureConnectionString, _azureContainerName);
                var createResponse = await container.CreateIfNotExistsAsync();
                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                var blob = container.GetBlobClient(dto.FileName);
                var file = await container.GetBlobsAsync().FirstOrDefaultAsync(x => x.Name == dto.FileName);

                if (file == null)
                {
                    return BadRequest("File not found");

                }

                var dec = await container.DeleteBlobIfExistsAsync(file.Name, DeleteSnapshotsOption.IncludeSnapshots);
                   if (dec)
                  {

                    return Ok("Successful removed");


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

        /// <summary>
        /// Converts the PowerPoint presentation(PPTX) to PDF document
        /// </summary>
        //[AcceptVerbs("Post")]
        //public async Task<HttpResponseMessage> ConvertToPdf()
        //{
        //    var formCollection = await Request.ReadFormAsync();
        //    var file = formCollection.Files.First();
        //    HttpResponseMessage httpResponseMessage;
        //    using (Stream stream = file.OpenReadStream())
        //    {
        //        try
        //        {
        //            //Opens the PowerPoint presentation (PPTX) from stream
        //            using (IPresentation presentation = Presentation.Open(stream))
        //            {
        //                //Initializes the ChartToImageConverter for converting charts during PPTX to PDF conversion
        //                presentation.ChartToImageConverter = new ChartToImageConverter
        //                {
        //                    ScalingMode = Syncfusion.OfficeChart.ScalingMode.Best
        //                };

        //                //Creates an instance of the PresentationToPdfConverterSettings
        //                PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings
        //                {
        //                    ShowHiddenSlides = true
        //                };
        //                //Converts PowerPoint presentation (PPTX) into PDF document
        //                PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation, settings);

        //                //Saves the PDF document to response stream
        //                MemoryStream memoryStream = new MemoryStream();
        //                pdfDocument.Save(memoryStream);
        //                memoryStream.Position = 0;
        //                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        //                {
        //                    Content = new StreamContent(memoryStream)
        //                };
        //                pdfDocument.Dispose();
        //            }
        //        }
        //        catch
        //        {
        //            httpResponseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
        //        }
        //    }
        //    return httpResponseMessage;
        //}

        [HttpPost("pdf")]
        public async Task<ActionResult> PPTXToPDF(IFormFile File)
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();


            //    FileStream fileStreamInput = new FileStream(basePath + @"/Presentation/Template.pptx", FileMode.Open, FileAccess.Read);
            //    IPresentation presentation = Presentation.Open(fileStreamInput);
            //    MemoryStream ms = new MemoryStream();

            //    //Saves the presentation to the memory stream.
            //    presentation.Save(ms);
            //    //Set the position of the stream to beginning.
            //    ms.Position = 0;
            //    return File(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation", "InputTemplate.pptx");
            //}
            //else
            //{
            //    FileStream fileStreamInput = new FileStream(basePath + @"/Presentation/Template.pptx", FileMode.Open, FileAccess.Read);
            //Open the existing PowerPoint presentation.
            IPresentation presentation = Presentation.Open("https://filesailogic.blob.core.windows.net/filecontainer/UI-UX.pptx");

                // Add a custom fallback font collection for Presentation.
                AddFallbackFonts(presentation);

                //Convert the PowerPoint document to PDF document.
                PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation);

                MemoryStream pdfStream = new MemoryStream();

                //Save the converted PDF document to Memory stream.
                pdfDocument.Save(pdfStream);
                pdfStream.Position = 0;

                //Close the PDF document.
                pdfDocument.Close(true);

                //Close the PowerPoint Presentation.
                presentation.Close();

                //Initialize the file stream to download the converted PDF.
                FileStreamResult fileStreamResult = new FileStreamResult(pdfStream, "application/pdf");
                //Set the file name.
                fileStreamResult.FileDownloadName = "Sample.pdf";

                return fileStreamResult;
            //}
        }

        /// <summary>
        /// Add a custom fallback font collection for IPresentation.
        /// </summary>
        /// <param name="presentation">Represent a presentation to add.</param>
        private void AddFallbackFonts(IPresentation presentation)
        {
            //Add customized fallback font names.

            // Arabic
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0600, 0x06ff, "Arial"));
            // Hebrew
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0590, 0x05ff, "Arial, David"));
            // Hindi
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0900, 0x097F, "Mangal"));
            // Chinese
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x4E00, 0x9FFF, "DengXian"));
            // Japanese
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x3040, 0x309F, "MS Mincho"));
            // Korean
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0xAC00, 0xD7A3, "Malgun Gothic"));
        }
        
}
}
