using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities.UserData;
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
    public class UserDataController : ControllerBase
    {
        private readonly IUserDataService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<UserDataController> _logger;

        public UserDataController(IUserDataService service, IMapper mapper, ILogger<UserDataController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }
        

        // GET: api/UserData/2?page=0&size=10
        [HttpGet("{userId}")]
        public async Task<IEnumerable<UserDataDto>> GetUserDataWithPagination(
            [FromRoute] int userId,
            [FromQuery] int page = 0, [FromQuery] int size = 10, [FromQuery] string modifiedAfter = null)
        {
            var modifiedAfterDateTime = _mapper.Map<DateTime?>(modifiedAfter);
            _logger.LogDebug($"Get Leads user's data for userId={userId} modified after {modifiedAfterDateTime} ,page={page}, size={size}");
            var uData = (await _service.GetUserDataPageAsync(userId, page, size, modifiedAfterDateTime))
                .Select(entity => _mapper.Map<UserDataDto>(entity));
            var withPagination = uData as UserDataDto[] ?? uData.ToArray();
            _logger.LogDebug($"returns {withPagination.Count()} objects");
            return withPagination;
        }

        // POST: api/UserData
        [HttpPost()]
        public async Task<UserDataDto> Upsert([FromBody] UserDataDto userDataDto, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Upserting  user's data {userDataDto.UserId}");
            var result =
                await _service.UpsertUserDataAsync(_mapper.Map<UserData>(userDataDto), cancellationToken);
            return _mapper.Map<UserDataDto>(result);
        }

        // POST: api/UserData/All
        [HttpPost("All")]
        public async Task<IEnumerable<UserDataDto>> UpsertAll([FromBody] UserDataDto[] leadUserDataDtos,
            CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Upserting  user's data -count={leadUserDataDtos.Length} ");
            var uds = leadUserDataDtos.Select(x => _mapper.Map<UserData>(x)).ToList();
            var result = (await _service.UpsertUserDataAsync(uds, cancellationToken))
                .Select(x => _mapper.Map<UserDataDto>(x)).ToList();
            return result;
        }
    }
}