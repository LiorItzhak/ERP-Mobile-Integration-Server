using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.DTOs;
using LogicLib.Services;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SalesmanController : ControllerBase
    {

        private readonly IDalService _dalService;
        private readonly IMapper _mapper;

        //auto-wired by asp startup
        public SalesmanController(IDalService dalService, IMapper mapper)
        {
            _dalService = dalService;
            _mapper = mapper;
        }

        // GET: api/salesman?page=0&size=10
        [HttpGet]
        public async Task<IEnumerable<SalesmanDto>> GetPage([FromQuery]int page = 0, [FromQuery]int size = 10)
        {
            return (await _dalService.CreateUnitOfWork().Salesmen
                    .GetAllAsync(PageRequest.Of(page, size,Sort<SalesmanEntity>.By(orderBy => orderBy.Sn))))
                .Select(entity=> _mapper.Map<SalesmanDto>(entity));
        }

        // GET: api/salesman/GetByID/5
        [HttpGet("GetByID/{id}")]
        public async Task<SalesmanDto> GetById([FromRoute]int id)
        {
            return _mapper.Map<SalesmanDto>(await _dalService.CreateUnitOfWork().Salesmen.FindByIdAsync(id));
        }
        // GET: api/salesman/All
        [HttpGet("All")]
        public async Task<IEnumerable<SalesmanDto>> GetAll()
        {
            return (await _dalService.CreateUnitOfWork().Salesmen.GetAllAsync(PageRequest.Of(0,int.MaxValue)))
                .Select(entity => _mapper.Map<SalesmanDto>(entity));
        }

    }
}
