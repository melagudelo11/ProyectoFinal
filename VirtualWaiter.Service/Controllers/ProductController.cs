using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Interface;

namespace VirtualWaiter.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }


        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var result = await _product.GetActive();
            return result;
        }

        [HttpPost]
        public async Task<bool> Save([FromBody] Product product)
        {
            var result = await _product.Save(product);
            return result;
        }
    }
}
