using Microsoft.AspNetCore.Mvc;
using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Interface;

namespace VirtualWaiter.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EaterytableController : ControllerBase
    {
        readonly IEaterytable _eaterytable;

        public EaterytableController(IEaterytable eaterytable)
        {
            _eaterytable = eaterytable;
        }


        [HttpGet]
        public async Task<IEnumerable<Eaterytable>> Get()
        {
            var result = await _eaterytable.GetActive();
            return result;
        }


        [HttpPost]
        [Route(nameof(EaterytableController.Save))]
        public async Task<bool> Save([FromBody] Eaterytable eaterytable)
        {
            var result = await _eaterytable.Save(eaterytable);
            return result;
        }


        [HttpGet]
        [Route(nameof(EaterytableController.GetById))]
        public async Task<Eaterytable> GetById(int id)
        {
            var result = await _eaterytable.GetById(id);
            return result;
        }

        [HttpPut]
        [Route(nameof(EaterytableController.Update))]
        public async Task<bool> Update([FromBody] Eaterytable eaterytable)
        {
            var result = await _eaterytable.Update(eaterytable);

            return result;
        }

        [HttpDelete]
        [Route(nameof(EaterytableController.Delete))]
        public async Task<bool> Delete(int id)
        {
            return await _eaterytable.Delete(id);
        }
    }
}
