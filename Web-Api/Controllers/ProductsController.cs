using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicLib.Services;
using Web_Api.DTOs.Products;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Web_Api.Utils;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductsService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;

        //auto-wired by asp startup
        public ProductsController(IProductsService service, IMapper mapper, ILogger<ProductsController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;

        }


        //GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAllProducts([FromQuery]int page = 0, [FromQuery]int size=10,[FromQuery] string updatedAfter = null)
        {
            var updatedAfterDateTime = _mapper.Map<DateTime?>(updatedAfter);
            _logger.LogDebug($"Get All Products updated after {updatedAfterDateTime} page = {page} size = {size}");
            var products = (await _service.GetProductsPageAsync(page,size,updatedAfterDateTime)).ToList();
            products.ForEach(x => x.PictureUrl = this.MapLocalPathToUri(x.PictureUrl));
            _logger.LogDebug($"returns {products.Count()} objects");
            return products.Select(x=> _mapper.Map<ProductDto>(x));
        }

        //GET: api/Products/Code/{code}
        [HttpGet("Code/{code}")]
        public async Task<ProductDto> GetProduct([FromRoute]string code)
        {
            _logger.LogDebug($"Get All Product with code {code}");
            var product = await _service.GetProductAsync(code);
            product.PictureUrl = this.MapLocalPathToUri(product.PictureUrl);
            return _mapper.Map<ProductDto>(product);
        }

        //GET: api/Products/Groups
        [HttpGet("Groups")]
        public async Task<IEnumerable<ProductGroupDto>> GetAllProductGroups([FromQuery]int page = 0, [FromQuery]int size = 10, [FromQuery] string updatedAfter = null)
        {
            var updatedAfterDateTime = _mapper.Map<DateTime?>(updatedAfter);

            _logger.LogDebug($"Get All Product Categories updated after {updatedAfterDateTime} page = {page} size = {size}");
            var productsGroups = (await _service.GetProductGroupsPageAsync(page, size, updatedAfterDateTime)).ToList();
            productsGroups.ForEach(x => x.PictureUrl = this.MapLocalPathToUri(x.PictureUrl));

            _logger.LogDebug($"returns {productsGroups.Count()} objects");

            return productsGroups.Select(x => _mapper.Map<ProductGroupDto>(x));
        }

        //GET: api/Products/Groups/Code/{code}
        [HttpGet("Groups/Code/{code:int}")]
        public async Task<ProductGroupDto> GetProductGroup([FromRoute]int code)
        {
            _logger.LogDebug($"Get All Product's Group with code {code}");

            var productGroup = await _service.GetProductGroupAsync(code);
            productGroup.PictureUrl = this.MapLocalPathToUri(productGroup.PictureUrl);

            return _mapper.Map<ProductGroupDto>(productGroup);
        }





    }
}