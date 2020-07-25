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
using Microsoft.Extensions.Logging;
using Web_Api.DTOs;

namespace Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController: ControllerBase
    {
        private readonly ILogger<AttachmentsController> _logger;
        private readonly IAttachmentsService _service;
        private readonly IMapper _mapper;

        public AttachmentsController(IAttachmentsService service, ILogger<AttachmentsController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }
        
        
        // GET: api/Attachments/5/1
        [HttpGet("{attachmentsCode}")]
        public async Task<List<AttachmentDto>> Get([FromRoute] int attachmentsCode,[FromQuery]string createdAfterDate = null)
        {
            return  (await _service.GetAttachments(attachmentsCode, _mapper.Map<DateTime?>(createdAfterDate)))
                .Select(x => _mapper.Map<AttachmentDto>(x)).ToList();
        }
        // GET: api/Attachments/5/1
        [HttpGet("{attachmentsCode}/{num}")]
        public async Task<AttachmentDto> Get([FromRoute] int attachmentsCode,[FromRoute] int num)
        {
            return _mapper.Map<AttachmentDto>(await _service.GetByKeyAsync(attachmentsCode,num));
        }
        
        // GET: api/Attachments?attachmentsCode=3888
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IEnumerable<AttachmentDto>> Post([FromForm] List<IFormFile> files,[FromQuery] int? attachmentsCode = null,CancellationToken cancellationToken = default)
        {
            var filesContainers =files.Select(x => new FileContainer
                {
                    FileStream = x.OpenReadStream(),
                    Name = x.FileName,
                    ContentDisposition = x.ContentDisposition,
                    Length = x.Length,
                    ContentType = x.ContentType,
                }
            );
            var attachments= await _service.CreateNewAttachments(filesContainers,attachmentsCode,cancellationToken);
            return attachments.Select(x => _mapper.Map<AttachmentDto>(x));
        }


        
        // [HttpPost("Attachments"), DisableRequestSizeLimit]
        // public async Task<IEnumerable<AttachmentDto>> PostAttachment([FromForm] List<IFormFile> files)
        // {
        //     var filesContainers =files.Select(x => new FileContainer
        //         {
        //             FileStream = x.OpenReadStream(),
        //             Name = x.FileName,
        //             ContentDisposition = x.ContentDisposition,
        //             Length = x.Length,
        //             ContentType = x.ContentType,
        //         }
        //     );
        //     var attachments = await _fileService.PostAttachmentsAsync(filesContainers);
        //     return attachments.Select(x => _mapper.Map<AttachmentDto>(x));
        // }

    }
}