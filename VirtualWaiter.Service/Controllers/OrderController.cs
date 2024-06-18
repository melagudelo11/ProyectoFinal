using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Interface;

namespace VirtualWaiter.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }


        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            var result = await _order.GetActive();
            return result;
        }


        [HttpPost]
        [Route(nameof(OrderController.Save))]
        public async Task<bool> Save([FromBody] Order order)
        {
            var result = await _order.Save(order);
            return result;
        }


        [HttpGet]
        [Route(nameof(OrderController.GetById))]
        public async Task<Order> GetById(int id)
        {
            var result = await _order.GetById(id);
            return result;
        }

        [HttpPut]
        [Route(nameof(OrderController.Update))]
        public async Task<bool> Update([FromBody] Order order)
        {
            var result = await _order.Update(order);

            return result;
        }

        [HttpDelete]
        [Route(nameof(OrderController.Delete))]
        public async Task<bool> Delete(int id)
        {
            return await _order.Delete(id);
        }
    }
}
