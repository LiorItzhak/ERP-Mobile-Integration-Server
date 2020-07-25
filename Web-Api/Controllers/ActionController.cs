using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrossLayersUtils;
using DataAccessLayer.Entities.BusinessPartners;
using LogicLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly ILogger<ActionController> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;

        public ActionController(IMapper mapper, ILogger<ActionController> logger , IServiceProvider serviceProvider)
        {
            _mapper = mapper;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }


        private static readonly Dictionary<string, Type> Services = typeof(IActionService).Assembly.ExportedTypes
           //.Where(x =>x.BaseType != null &&   x.GetInterfaces().Any(i=>i.IsGenericType && typeof(IActionService<>).IsAssignableFrom(i.GetGenericTypeDefinition())) && !x.IsInterface && !x.IsAbstract)
            .Where(x => typeof(IActionService).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .Where(x => x.GetCustomAttributes(typeof(ActionAttribute), true).OfType<ActionAttribute>().Any())
            .ToDictionary(x =>
                x.GetCustomAttributes(typeof(ActionAttribute), true).OfType<ActionAttribute>().First().Type.ToUpper());


        
        [HttpPost("{type}")]
        public async Task<object> PostAction([FromRoute] string type, [FromBody]Dictionary<string, string> actionProps,CancellationToken cancellationToken)
        {
            var srvType = Services.GetValueOrDefault(type.ToUpper(),null)??  throw new NotFoundException($"type {type} unsupported");
            var srv = _serviceProvider.GetService(srvType) as IActionService ?? throw new Exception($"service for type {type} unprovided");
            _logger.LogInformation($"using service {type}");
            var r = await srv.ExecuteAction(actionProps, cancellationToken);
            
            //TODO check dto mapper profile
            var mapper = _mapper.ConfigurationProvider
                .GetAllTypeMaps().FirstOrDefault(x => x.SourceType == r.GetType());
            r= mapper != null ? _mapper.Map(r, mapper.SourceType, mapper.DestinationType) : r;
           _logger.LogInformation($"return type {r.GetType().Name}");
           return r;

        }
    }
    
    
}