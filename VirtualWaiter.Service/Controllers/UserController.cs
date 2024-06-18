using Microsoft.AspNetCore.Mvc;
using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Interface;

namespace VirtualWaiter.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }


        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var result = await _user.GetActive();
            return result;
        }


        [HttpPost]
        [Route(nameof(UserController.Save))]
        public async Task<bool> Save([FromBody] User user)
        {
            var result = await _user.Save(user);
            return result;
        }


        [HttpGet]
        [Route(nameof(UserController.GetById))]
        public async Task<User> GetById(int id)
        {
            var result = await _user.GetById(id);
            return result;
        }

        [HttpPut]
        [Route(nameof(UserController.Update))]
        public async Task<bool> Update([FromBody] User user)
        {
            var result = await _user.Update(user);

            return result;
        }

        [HttpDelete]
        [Route(nameof(UserController.Delete))]
        public async Task<bool> Delete(int id)
        {
            return await _user.Delete(id);
        }
    }
}
