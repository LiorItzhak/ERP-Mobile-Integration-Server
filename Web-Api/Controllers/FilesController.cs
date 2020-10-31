using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LogicLib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;

namespace Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [OferInterceptor]

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

        

        [HttpGet("{fileKey}")]
        public async Task<FileStreamResult> GetFile([FromRoute] string fileKey)
        {
            var fileData = await _fileService.GetFileAsync(fileKey);
            if (!_contentTypeProvider.TryGetContentType(fileKey, out var contentType))
                contentType = "application/octet-stream";
            return File(fileData, contentType);
        }
        

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IEnumerable<string>> Post([FromForm] List<IFormFile> files,
            CancellationToken cancellationToken = default)
        {
            var filesContainers = files.Select(x => new FileContainer
                {
                    FileStream = x.OpenReadStream(),
                    Name = x.FileName,
                    ContentDisposition = x.ContentDisposition,
                    Length = x.Length,
                    ContentType = x.ContentType,
                }
            );
            return await _fileService.SaveFilesAsync(filesContainers, false,cancellationToken);
        }

        

        //***OLD API ***///
        [HttpGet("Bitmap/{fileName}")]
        [Obsolete]
        public async Task<FileContentResult> GetBitmap([FromRoute] string fileName)
        {
            var fileData = await _fileService.GetBitmapAsync(fileName);
            if (!_contentTypeProvider.TryGetContentType(fileName, out var contentType))
                contentType = "application/octet-stream";
            return File(fileData, contentType);
        }
        


        [HttpGet("Pdf/{objectKey}")]
        
        public FileStreamResult GetPdfForObject([FromRoute] string objectKey, [FromQuery] string createdAfter = null)
        {
            var fileData = _fileService.GetPdfForObjectAsync(objectKey, _mapper.Map<DateTime?>(createdAfter));
            return File(fileData, "application/pdf");
        }
    }
}