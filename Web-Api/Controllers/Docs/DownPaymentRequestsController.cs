using AutoMapper;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using LogicLib.Services.Docs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.DTOs.Documents;

namespace Web_Api.Controllers.Docs
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DownPaymentRequestsController : DocumentController<DownPaymentRequestDto, DownPaymentRequest,
        DownPaymentRequestHeader>
    {
        private readonly IDownPaymentRequestsService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<DownPaymentRequestsController> _logger;

        //auto-wired by asp startup
        public DownPaymentRequestsController(IDownPaymentRequestsService service, IMapper mapper,
            ILogger<DownPaymentRequestsController> logger) :
            base(service, mapper, logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;

        }
    }
}