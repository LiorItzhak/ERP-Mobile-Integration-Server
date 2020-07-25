using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using FluentValidation;
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
    public class InvoicesController : DocumentController<InvoiceDto,InvoiceEntity,InvoiceHeaderEntity>
    {
        private readonly IInvoiceService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<InvoicesController> _logger;

        //auto-wired by asp startup
        public InvoicesController(IInvoiceService service, IMapper mapper, ILogger<InvoicesController> logger):
            base(service,mapper,logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;

        }



    }
}