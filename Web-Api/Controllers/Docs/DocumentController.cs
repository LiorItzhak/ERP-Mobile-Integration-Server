using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Utils;
using FluentValidation;
using LogicLib.Services;
using LogicLib.Services.Docs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.Controllers.Docs.Utils;
using Web_Api.DTOs.Documents;

namespace Web_Api.Controllers.Docs
{
    [OferInterceptor]
    public abstract class DocumentController<TDocumentDto, TDocument, TDocumentHeader> : ControllerBase
        where TDocumentDto : DocumentDto
        where TDocumentHeader : DocumentHeaderEntity
        where TDocument : TDocumentHeader, IDocumentEntity

    {
        private readonly IDocumentService<TDocument, TDocumentHeader> _service;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentController<TDocumentDto, TDocument, TDocumentHeader>> _logger;

        //auto-wired by asp startup
        protected DocumentController(IDocumentService<TDocument, TDocumentHeader> service, IMapper mapper,
            ILogger<DocumentController<TDocumentDto, TDocument, TDocumentHeader>> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<TDocumentDto>> GetPage(
            [FromQuery] int page = 0,
            [FromQuery] int size = 10,
            [FromQuery] string businessPartnerKey = null,
            [FromQuery] string salesmanKey = null,
            [FromQuery] bool? isOpen = null,
            [FromQuery] string modifiedAfter = null)
        {
           
            var r = await _service.GetPageAsync(
                businessPartnerKey,
                salesmanKey != null ? Convert.ToInt32(salesmanKey)  : new int?(),
                isOpen,
                _mapper.Map<DateTime?>(modifiedAfter),
                page,size);
            return r.Select(entity => _mapper.Map<TDocumentDto>(entity));
        }

        

        // GET: api/{DocumentName}/{docKey}
        [HttpGet("{docKey:int}")]
        public async Task<TDocumentDto> Get([FromRoute] int docKey)
        {
            _logger.LogDebug($"Get {typeof(TDocument).Name} key =  {docKey}");
            var temp = _mapper.Map<TDocumentDto>(await _service.GetByDocKeyAsync(docKey));
            return temp;
        }

        // GET: api/{DocumentName}/DocNumber{docNumber}
        [HttpGet("DocNumber/{docNumber:int}")]
        public async Task<TDocumentDto> GetByDocNumber([FromRoute] int docNumber)
        {
            _logger.LogDebug($"Get {typeof(TDocument).Name} sn =  {docNumber}");

            var temp = _mapper.Map<TDocumentDto>(await _service.GetByDocNumberAsync(docNumber));
            return temp;
        }


        // PUT: api/{DocumentName}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TDocumentDto document, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Updating {typeof(TDocument).Name}   {document.Key} for Customer {document.CustomerSn}");
            try
            {
                var result =
                    _mapper.Map<TDocumentDto>(await _service.UpdateDocument(_mapper.Map<TDocument>(document),
                        cancellationToken));
                _logger.LogDebug(
                    $"{typeof(TDocument).Name}  for Customer: {result.CustomerSn} updated, Key:{result.Key}");
                return Ok(result);
            }
            catch (ValidationException error)
            {
                _logger.LogDebug(
                    $"Updating {typeof(TDocument).Name}  {document.Key} for Customer:{document.CustomerSn} failed - validation error: {error.Message}");
                return BadRequest(error.Message);
            }
            catch (Exception e)
            {
                _logger.LogWarning(
                    $"Updating {typeof(TDocument).Name}  {document.Key} for Customer:{document.CustomerSn} failed - unknown error : {e.Message} ");
                throw;
            }
        }


        // POST: api/{DocumentName}
        [HttpPost]
        public async Task<IActionResult> CreateNew([FromBody] TDocumentDto document,
            CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Adding new Quotation for Customer {document.CustomerSn}");
            try
            {
                var result =
                    _mapper.Map<TDocumentDto>(await _service.CreateNewDocument(_mapper.Map<TDocument>(document),
                        cancellationToken));
                _logger.LogDebug(
                    $" {typeof(TDocument).Name} for Customer: {result.CustomerSn} added, Key:{result.Key}");
                return Ok(result);
            }
            catch (ValidationException error)
            {
                _logger.LogDebug(
                    $"Add new  {typeof(TDocument).Name} for Customer:{document.CustomerSn} failed - validation error: {error.Message}");
                return BadRequest(error.Message);
            }
            catch (Exception e)
            {
                _logger.LogWarning(
                    $"Add new  {typeof(TDocument).Name} for Customer:{document.CustomerSn}  failed - unknown error : {e.Message} ");
                throw;
            }
        }
    }
}