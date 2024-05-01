using Business.Abstracts;
using Business.Concrates;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpPost]
        public async Task Add(Product product)
        {
           await _productService.Add(product);
        }

        [HttpGet("sync")]
        public string Sync() 
        {
            Thread.Sleep(5000); 
            return "SYNC ENDPOINT";
        }

        [HttpGet("Async")]
        public async Task<string> Async()
        {
            Task.Delay(5000);
            return "ASYNC ENDPOINT";
        }

    }
}
