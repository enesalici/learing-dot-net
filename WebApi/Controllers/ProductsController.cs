using Business.Abstracts;
using Business.Feature.Products.Commands.Create;
using Business.Feature.Products.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductsController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpPost] 
        public async Task<IActionResult> Add([FromBody] CreateProductCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListQuery query)
        {
           var result = await _mediator.Send(query);

            return Ok(result);
        }

         
    }
}
