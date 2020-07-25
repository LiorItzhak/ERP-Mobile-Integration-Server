using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities;
using LogicLib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.DTOs;
using Web_Api.Installers;
using Web_Api.Utils;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserLocationController: ControllerBase
    {
        private readonly IUserLocationService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<UserLocationController> _logger;

        public UserLocationController(IUserLocationService service, IMapper mapper,
            ILogger<UserLocationController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }
        
        // GET: api/UserLocation/154645646?toDateTime=1516515616&page=0&size=10&employeeSn=2
        [Authorize(Policy =Authorizations.RequireAdminOrManagerRole)]
        [HttpGet("{fromDateTime}")]
        public async Task<IEnumerable<UserLocationDto>> GetWithPagination(
            [FromRoute]string fromDateTime,
            [FromQuery]string toDateTime = null,
            [FromQuery]int? employeeSn = null,
            [FromQuery]int page = 0,
            [FromQuery]int size=10)
        {

            var fromDateTimeM = _mapper.Map<DateTime>(fromDateTime);
            var toDateTimeM = _mapper.Map<DateTime?>(toDateTime);

            _logger.LogDebug($"Get UserLocation from  {fromDateTimeM}  to {toDateTimeM},page = {page}, size = {size}");
            var userLocations = (await _service.Get(page, size,fromDateTimeM,toDateTimeM,employeeSn ))
                .Select(entity => _mapper.Map<UserLocationDto>(entity));
            var withPagination = userLocations as UserLocationDto[] ?? userLocations.ToArray();
            _logger.LogDebug($"returns {withPagination.Count()} objects");
            return withPagination;
        }
        
        // POST: api/UserLocation
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]IEnumerable<UserLocationDto> userLocations)
        {
            var userLocationDtos = userLocations as UserLocationDto[] ?? userLocations.ToArray();
            _logger.LogDebug($"Adding new UserLocations from for employee {userLocationDtos.First().EmployeeSn}");
            var userLocationsWithDeviceId = userLocationDtos.Select(x =>
                {
                    var userLocation = _mapper.Map<UserLocation>(x);
                    userLocation.DeviceId =string.Empty;//TODO
                    return userLocation;
                }).ToList();
            await _service.Add(userLocationsWithDeviceId);
            return Ok();
        }

        // GET: api/UserLocation/LastKnown/1
        [Authorize(Policy =Authorizations.RequireAdminOrManagerRole)]
        [HttpGet("LastKnown/{employeeSn:int}")]
        public async Task<UserLocationDto> GetLastKnownLocation([FromRoute]int employeeSn)
        {
            _logger.LogDebug($"Get last known UserLocations  for employee {employeeSn}");
            return _mapper.Map<UserLocationDto>(await _service.GetLastKnownLocation(employeeSn));
        }
        
    }
}