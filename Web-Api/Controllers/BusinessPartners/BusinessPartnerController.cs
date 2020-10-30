using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities.BusinessPartners;
using LogicLib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.DTOs;

namespace Web_Api.Controllers.BusinessPartners
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [OferInterceptor]
    public class BusinessPartnerController : ControllerBase
    {

        private readonly IBusinessPartnerService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<BusinessPartnerController> _logger;



        public BusinessPartnerController(IBusinessPartnerService service, IMapper mapper,
            ILogger<BusinessPartnerController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }


        // GET: api/BusinessPartner?page=0&size=10
        [HttpGet]
      
        public async Task<IEnumerable<BusinessPartnerDto>> GetWithPagination([FromQuery] int page = 0,
            [FromQuery] int size = 10, [FromQuery] string modifiedAfter = null)
        {
            var modifiedAfterDateTime = _mapper.Map<DateTime?>(modifiedAfter);
            _logger.LogDebug($"Get Customers updated after {modifiedAfterDateTime} ,page = {page}, size = {size}");
            var customers = (await _service.GetPageAsync(page, size, modifiedAfterDateTime))
                .Select(entity => _mapper.Map<BusinessPartnerDto>(entity));
            var withPagination = customers as BusinessPartnerDto[] ?? customers.ToArray();
            _logger.LogDebug($"returns {withPagination.Count()} objects");
            return withPagination;
        }


        // GET: api/BusinessPartner/Balance/21697
        [HttpGet("Balance/{cid}")]
        public async Task<IEnumerable<AccountBalanceRecordDto>> GetCustomerAccountBalance(string cid)
        {
            _logger.LogDebug($"Request balance of customer : {cid} ");
            var e = (await _service.GetBalanceAsync(cid));
            var r = e.Select(x => _mapper.Map<AccountBalanceRecordDto>(x));
            return r;
        }


        //GET: api/BusinessPartner/5
        [HttpGet("{key}")]
        public async Task<BusinessPartnerDto> GetByCId(string key)
        {
            var bp = _mapper.Map<BusinessPartnerDto>(await _service.GetByKeyAsync(key));
            return bp;
        }


        // POST: api/BusinessPartner
        [HttpPost]
        public async Task<BusinessPartnerDto> AddNew([FromBody] BusinessPartnerDto businessPartner,
            CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Adding new customer {businessPartner.Name}");
            var result =
                await _service.AddBusinessPartnerAsync(_mapper.Map<BusinessPartner>(businessPartner),
                    cancellationToken);
            return _mapper.Map<BusinessPartnerDto>(result);
        }

        // PUT: api/BusinessPartner
        [HttpPut("{cid}")]
        public async Task<BusinessPartnerDto> Update([FromRoute] string cid,
            [FromBody] BusinessPartnerDto businessPartner, CancellationToken cancellationToken)
        {
            var result = await _service
                .UpdateBusinessPartnerAsync(cid, _mapper.Map<BusinessPartner>(businessPartner), cancellationToken);
            return _mapper.Map<BusinessPartnerDto>(result);
        }


        // GET: api/BusinessPartner/Groups
        [HttpGet("Groups")]
        public async Task<IEnumerable<CardGroupDto>> GetAllGroups()
        {
            return (await _service.GetCardGroupsAsync())
                .Select(x => _mapper.Map<CardGroupDto>(x));
        }

        // GET: api/BusinessPartner/Indicators

        [HttpGet("Indicators")]
        public async Task<IEnumerable<IndicatorDto>> GetAllIndicators()
        {
            return (await _service.GetCardIndicatorsAsync())
                .Select(x => _mapper.Map<IndicatorDto>(x));
        }

        // GET: api/BusinessPartner/Industries

        [HttpGet("Industries")]
        public async Task<IEnumerable<IndustryDto>> GetAllIndustries()
        {
            return (await _service.GetCardIndustriesAsync())
                .Select(x => _mapper.Map<IndustryDto>(x));
        }
    }
}