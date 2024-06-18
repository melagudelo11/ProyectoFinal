using VirtualWaiter.Service.Data.Models;

namespace VirtualWaiter.Service.Interface
{
    public interface IUser
    {
        public Task<IEnumerable<User>> GetActive();
        public Task<bool> Save(User user);
        public Task<User> GetById(int id);
        public Task<bool> Update(User user);
        Task<bool> Delete(int id);
    }
}
