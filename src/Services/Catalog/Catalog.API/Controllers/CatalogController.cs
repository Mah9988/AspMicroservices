using Catalog.API.Models;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CatalogController> _logger;    

        public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() 
        {
            return Ok(await _repository.GetProducts());
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProductsById(string id)
        {
            var product = await _repository.GetProduct(id);
            if(product == null)
            {
                _logger.LogError($"Product with id : {id} not found");
                return NotFound();
            }
            return Ok(product);
        }

        // action here Refer to the name of function ( GetProductsByCategory )
        [HttpGet("[action]/{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            return Ok(await _repository.GetProductsByCategory(category));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _repository.CreateProduct(product);
            return CreatedAtRoute("GetProduct", new {id =product.Id}, product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _repository.UpdateProduct(product));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }

    }
}
