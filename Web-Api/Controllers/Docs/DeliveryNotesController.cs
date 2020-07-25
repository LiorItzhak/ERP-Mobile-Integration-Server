using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using LogicLib.Services.Docs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.DTOs.Documents;

namespace Web_Api.Controllers.Docs
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DeliveryNotesController : DocumentController<DeliveryNoteDto,DeliveryNoteEntity,DeliveryNoteHeaderEntity>
    {
        private readonly IDeliveryNotesService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<DeliveryNotesController> _logger;

        //auto-wired by asp startup
        public DeliveryNotesController(IDeliveryNotesService service, IMapper mapper, ILogger<DeliveryNotesController> logger):
            base(service,mapper,logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;

        }

      
    }
}