using Business.Abstracts;
using Business.Feature.Products.Commands.Create;
using Business.Feature.Products.Commands.Delete;
using Business.Feature.Products.Commands.Update;
using Business.Feature.Products.Queries.GetById;
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
        public async Task<IActionResult> GetAll([FromQuery] GetListQuery query) { 
        

           var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdQuery query = new GetByIdQuery() { Id = id};    
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteProductCommand command = new DeleteProductCommand() {  Id = id };
            await _mediator.Send(command);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var resault = await _mediator.Send(command);
            return Ok(resault);
        }


    }

}
