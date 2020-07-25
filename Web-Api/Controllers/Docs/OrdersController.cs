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
    public class OrdersController : DocumentController<OrderDto,OrderEntity,OrderHeaderEntity>
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersController> _logger;

        //auto-wired by asp startup
        public OrdersController(IOrderService service, IMapper mapper, ILogger<OrdersController> logger):
            base(service,mapper,logger)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        

        // PUT: api/Orders/Cancel/{docKey}
        [HttpPut("Cancel/{docKey:int}")]
        public async Task<IActionResult> CancelDocument(int docKey, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Canceling Order {docKey}");
            try
            {
                var result = _mapper.Map<OrderDto>(await _service.CancelDocument(docKey, cancellationToken));
                _logger.LogDebug($"Order for Customer: {result.CustomerSn} Canceled, Key:{result.Key}");
                return Ok(result);
            }
            catch (ValidationException error)
            {
                _logger.LogDebug($"Canceling Order {docKey}failed - validation error: {error.Message}");
                return BadRequest(error.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"Canceling Order {docKey} failed - unknown error : {e.Message} ");
                throw;
            }
        }

        // PUT: api/Orders/Close/{docKey}
        [HttpPut("Close/{docKey:int}")]
        public async Task<IActionResult> CloseDocument(int docKey, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Closing Order {docKey}");
            try
            {
                var result = _mapper.Map<OrderDto>(await _service.CloseDocument(docKey, cancellationToken));
                _logger.LogDebug($"Order for Customer: {result.CustomerSn} closed, Key:{result.Key}");
                return Ok(result);
            }
            catch (ValidationException error)
            {
                _logger.LogDebug($"Closing Order {docKey}failed - validation error: {error.Message}");
                return BadRequest(error.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"Closing Order {docKey} failed - unknown error : {e.Message} ");
                throw e;
            }
        }
        
     
    }
}