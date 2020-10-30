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
using Web_Api.DTOs;

namespace Web_Api.Controllers.BusinessPartners
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    [OferInterceptor]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _service;
        private readonly IMapper _mapper;

        public ActivityController(IActivityService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{code}")]
        public async Task<ActivityDto> GetByCode([FromRoute] int code)
        {
            var response = await _service.GetActivityAsync(code);
            return _mapper.Map<ActivityDto>(response);
        }

        [HttpGet]
        public async Task<IEnumerable<ActivityDto>> GetPage(
            [FromQuery] int page,
            [FromQuery] int size = 10,
            [FromQuery] string businessPartnerCode = null,
            [FromQuery] int? handleByEmployee = null,
            [FromQuery] string modifiedAfter = null
        )
        {
            var response = await _service.GetActivitiesAsync(page, size, businessPartnerCode, handleByEmployee,
                _mapper.Map<DateTime?>(modifiedAfter));
            return response.Select(x => _mapper.Map<ActivityDto>(x));
        }


        [HttpPut("{code}")]
        public async Task<ActivityDto> Update([FromRoute] int code, [FromBody] ActivityDto activity, CancellationToken cancellationToken)
        {
            var response = await _service.UpdateActivityAsync(code, _mapper.Map<Activity>(activity),cancellationToken);
            return _mapper.Map<ActivityDto>(response);
        }

        [HttpPost]
        public async Task<ActivityDto> Create([FromBody] ActivityDto activity, CancellationToken cancellationToken)
        {
            var response = await _service.CreateNewActivityAsync(_mapper.Map<Activity>(activity),cancellationToken);
            return  _mapper.Map<ActivityDto>(response);
        }
        

        [HttpGet("types")]
        public async Task<IEnumerable<ActivityTypeDto>> GetActivitiesTypes()
        {
            var types = await _service.GetActivitiesTypesAsync();
            return types.Select(x => _mapper.Map<ActivityTypeDto>(x));
        }
        
        [HttpGet("subjects")]
        public async Task<IEnumerable<ActivitySubjectDto>> GetActivitySubjects()
        {
            var subjects = await _service.GetActivitySubjectsAsync();
            return subjects.Select(x => _mapper.Map<ActivitySubjectDto>(x));
        }
        
    }
}