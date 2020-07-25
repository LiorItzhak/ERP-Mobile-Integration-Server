using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using LogicLib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.DTOs;

namespace Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly IDalService _dalService;
        private readonly IMapper _mapper;

        //auto-wired by asp startup
        public CompanyController(IDalService dalService, IMapper mapper)
        {
            _dalService = dalService;
            _mapper = mapper;
        }



        // GET: api/Company
        [HttpGet]
        public async Task<CompanyDto> Get()
        {
            return _mapper.Map<CompanyDto>(await _dalService.CreateUnitOfWork().Company.GetAsync());
        }
    }
}
