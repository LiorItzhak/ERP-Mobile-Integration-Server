using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LogicLib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.DTOs;
using Web_Api.Utils;

namespace Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesTimeClockController : Controller
    {
        private readonly IEmployeeTimeClockService _service;
        private readonly ILogger<EmployeesTimeClockController> _logger;
        private readonly IMapper _mapper;

        public EmployeesTimeClockController(IEmployeeTimeClockService service, IMapper mapper,
            ILogger<EmployeesTimeClockController> logger)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpPost("CheckIn")]
        public async Task<EmployeeTimeClockDto> CheckIn([FromBody] CheckInRequestDto checkInRequest,
            CancellationToken cancellationToken)
        {
            var response = await _service.CheckInAsync(_mapper.Map<CheckInRequest>(checkInRequest), cancellationToken);
            return _mapper.Map<EmployeeTimeClockDto>(response);
        }

        [HttpPost("CheckOut")]
        public async Task<EmployeeTimeClockDto> CheckOut([FromBody] CheckOutRequestDto checkOutRequest,
            CancellationToken cancellationToken)
        {
            var response =
                await _service.CheckOutAsync(_mapper.Map<CheckOutRequest>(checkOutRequest), cancellationToken);
            return _mapper.Map<EmployeeTimeClockDto>(response);
        }

        [HttpGet("GetLastTimeClock/{employeeSn}")]
        public async Task<EmployeeTimeClockDto> GetLastTimeClock([FromRoute] int employeeSn)
        {
            var response = await _service.GetLastTimeClock(employeeSn);
            return _mapper.Map<EmployeeTimeClockDto>(response);
        }


        // [Authorize(Policy = Authorizations.RequireAdminOrManagerRole)]
        [AllowAnonymous]
        [HttpGet("CSV")]
        public async Task<IActionResult> GetCsv([FromQuery] string fromDate, [FromQuery] string toDate,
            [FromQuery] int? employeeSn = null, [FromQuery] bool considerTimeOfDay = false)
        {
            // ReSharper disable  InconsistentNaming
            var _fromDate = _mapper.Map<DateTimeOffset>(fromDate);
            var _toDate = _mapper.Map<DateTimeOffset>(toDate);
            var csvBytes =
                await _service.GenerateCsvBytes(_fromDate, _toDate, employeeSn, considerTimeOfDay);
            return File(csvBytes, "application/octet-stream", 
                $"Reports_{_fromDate}_{_toDate}.csv");
        }


        [Authorize(Policy = Authorizations.RequireAdminOrManagerRole)]
        [HttpGet]
        public async Task<IEnumerable<EmployeeTimeClockDto>> GetPage([FromQuery] string fromUtcDateTime,
            [FromQuery] string toUtcDateTime, [FromQuery] int page, [FromQuery] int size = 10,
            [FromQuery] int? employeeSn = null, [FromQuery] bool considerTimeOfDay = false)
        {
            var fromLocalDateTime = _mapper.Map<DateTimeOffset>(fromUtcDateTime);
            var toLocalDateTime = _mapper.Map<DateTimeOffset>(toUtcDateTime);
            return (await _service.GeTimeClocks(fromLocalDateTime, toLocalDateTime, page, size, employeeSn,
                    considerTimeOfDay))
                .Select(x => _mapper.Map<EmployeeTimeClockDto>(x));
        }
    }
}