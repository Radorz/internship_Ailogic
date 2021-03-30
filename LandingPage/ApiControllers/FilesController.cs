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
using Aspose.Slides;
using Aspose.Slides.Export;
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
                    Presentation presentation = new Presentation(file.OpenReadStream());

                    // Save the presentation as PDF
                    presentation.Save("PPT-to-PDF.pdf", SaveFormat.Pdf);
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
                    filesDTO.IdAssignments = DTO.id_assignments;
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
        /// Converts the PowerPoint presentation (PPTX) to PDF document
        /// </summary>
        //[AcceptVerbs("Post")]
        //public HttpResponseMessage ConvertToPdf()
        //{
        //    HttpResponseMessage httpResponseMessage;
        //    using (Stream stream = Request.)
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
        //                //Adds watermark at top left corner of first page in the generated PDF document to denote that it is generated using demo web service
        //                //To remove this watermark, comment or delete the codes within below "if" statement
        //                if (pdfDocument.Pages.Count > 0)
        //                {
        //                    PdfPage pdfPage = pdfDocument.Pages[0];
        //                    //Create PDF font and PDF font style using Font
        //                    Font font = new Font("Times New Roman", 12f, FontStyle.Regular);
        //                    PdfFont pdfFont = new PdfTrueTypeFont(font, false);
        //                    //Create a new PDF brush to draw the rectangle
        //                    PdfBrush pdfBrush = new PdfSolidBrush(Color.White);
        //                    //Draw rectangle in the current page
        //                    pdfPage.Graphics.DrawRectangle(pdfBrush, 0f, 0f, 228f, 20.65f);
        //                    //Create a new brush to draw the text
        //                    pdfBrush = new PdfSolidBrush(Color.Red);
        //                    //Draw text in the current page
        //                    pdfPage.Graphics.DrawString("Created by Syncfusion – Presentation library", pdfFont,
        //                        pdfBrush, 6f, 4f);
        //                }
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


    }
}
