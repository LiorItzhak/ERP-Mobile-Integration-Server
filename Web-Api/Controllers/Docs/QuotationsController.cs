using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using FluentValidation;
using LogicLib.Services;
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
    public class QuotationsController  : DocumentController<QuotationDto,QuotationEntity,QuotationHeaderEntity>
    {

        private readonly IQuotationService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<QuotationsController> _logger;

        //auto-wired by asp startup
        public QuotationsController(IQuotationService service, IMapper mapper, ILogger<QuotationsController> logger): 
            base(service,mapper,logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;

        }
        

        // PUT: api/Quotations/Cancel/{docKey}
        [HttpPut("Cancel/{docKey:int}")]
        public async Task<IActionResult> CancelDocument(int docKey, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Canceling Quotation {docKey}");
            try
            {
                var result = _mapper.Map<QuotationDto>(await _service.CancelDocument( docKey, cancellationToken));
                _logger.LogDebug($"Quotation for Customer: {result.CustomerSn} Canceled, Key:{result.Key}");
                return Ok(result);
            }
            catch (ValidationException error)
            {
                _logger.LogDebug($"Canceling Quotation {docKey}failed - validation error: {error.Message}");
                return BadRequest(error.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"Canceling Quotation {docKey} failed - unknown error : {e.Message} ");
                throw e;
            }

        }

        // PUT: api/Quotations/Close/{docKey}
        [HttpPut("Close/{docKey:int}")]
        public async Task<IActionResult> CloseDocument(int docKey, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Closing Quotation {docKey}");
            try
            {
                var result = _mapper.Map<QuotationDto>(await _service.CloseDocument(docKey, cancellationToken));
                _logger.LogDebug($"Quotation for Customer: {result.CustomerSn} closed, Key:{result.Key}");
                return Ok(result);
            }
            catch (ValidationException error)
            {
                _logger.LogDebug($"Closing Quotation {docKey}failed - validation error: {error.Message}");
                return BadRequest(error.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"Closing Quotation {docKey} failed - unknown error : {e.Message} ");
                throw;
            }

        }
        
    }
}