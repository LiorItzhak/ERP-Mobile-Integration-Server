using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities;
using LogicLib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using Web_Api.DTOs;

namespace Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ILogger<FilesController> _logger;
        private readonly FileExtensionContentTypeProvider _contentTypeProvider = new FileExtensionContentTypeProvider();
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;



        public FilesController(ILogger<FilesController> logger, IFileService fileService, IMapper mapper)
        {
            _logger = logger;
            _fileService = fileService;
            _mapper = mapper;
        }

        

        [HttpGet("Bitmap/{fileName}")]
        public async Task<FileContentResult> GetBitmap([FromRoute] string fileName)
        {
            var fileData = await _fileService.GetBitmapAsync(fileName);
            if (!_contentTypeProvider.TryGetContentType(fileName, out var contentType))
                contentType = "application/octet-stream";
            return File(fileData, contentType);
        }




        [HttpGet("Attachments/{fileName}")]
        public async Task<FileStreamResult> GetAttachment([FromRoute] string fileName)
        {
            var fileData = await _fileService.GetAttachmentAsync(fileName);
            if (!_contentTypeProvider.TryGetContentType(fileName, out var contentType))
                contentType = "application/octet-stream";
            return File(fileData, contentType);
        }

        // GET: api/Files/FromLocal/file.jpg
        [HttpGet("FromLocal/{fileName}")]
        public async Task<IActionResult> GetProductPicture([FromRoute] string fileName) => await GetBitmap(fileName);
        
        
        [HttpGet("Pdf/{objectKey}")]
        public FileStreamResult GetPdfForObject([FromRoute] string objectKey,[FromQuery] string createdAfter = null)
        {
            var fileData =  _fileService.GetPdfForObjectAsync(objectKey,_mapper.Map<DateTime?>(createdAfter));
            return File(fileData, "application/pdf");
        }
        
        
    }
}