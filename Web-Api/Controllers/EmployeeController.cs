using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.DTOs;
using LogicLib.Services;
using AutoMapper;
using Bogus.Extensions;
using Microsoft.AspNetCore.Authorization;
using Web_Api.Utils;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    [OferInterceptor]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeesService _employeeService;
        private readonly IMapper _mapper;

        //Auto-wired by asp startup
        public EmployeeController(IEmployeesService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/Employee?page=0&size=20?modifiedAfter=125000
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetPage([FromQuery]int page = 0, [FromQuery]int size=10, [FromQuery] string modifiedAfter = null)
        {
            var emps = (await _employeeService.GetEmployeesPageAsync(page, size,_mapper.Map<DateTime?>(modifiedAfter) )).ToList();
            emps.ForEach(x => x.PicPath = this.MapLocalPathToUri(x.PicPath));
            return emps.Select(entity => _mapper.Map<EmployeeDto>(entity));


        }

        // GET: api/Employee/GetBySN/5
        [HttpGet("GetBySN/{sn}")]
        public async Task<EmployeeDto> Get([FromRoute]int sn)
        {
            var emp = await _employeeService.FindEmployeeBySnAsync(sn);
            emp.PicPath = this.MapLocalPathToUri(emp.PicPath);

            return _mapper.Map<EmployeeDto>(emp);
        }
        



    }
}
