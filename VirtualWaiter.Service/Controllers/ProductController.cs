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
        [Route(nameof(ProductController.Save))]
        public async Task<bool> Save([FromBody] Product product)
        {
            var result = await _product.Save(product);
            return result;
        }


        [HttpGet]
        [Route(nameof(ProductController.GetById))]
        public async Task<Product> GetById(int id)
        {
            var result = await _product.GetById(id);
            return result;
        }

        [HttpPut]
        [Route(nameof(ProductController.Update))]
        public async Task<bool> Update([FromBody] Product product)
        {
             var result = await _product.Update(product);

            return result;
        }

        [HttpDelete]
        [Route(nameof(ProductController.Delete))]
        public async Task<bool> Delete(int id)
        {
            return await _product.Delete(id);
        }
    }
}
