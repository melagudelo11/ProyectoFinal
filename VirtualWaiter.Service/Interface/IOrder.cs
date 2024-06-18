using VirtualWaiter.Service.Data.Models;

namespace VirtualWaiter.Service.Interface
{
    public interface IOrder
    {
        public Task<IEnumerable<Order>> GetActive();
        public Task<bool> Save(Order order);
        public Task<Order> GetById(int id);
        public Task<bool> Update(Order order);
        Task<bool> Delete(int id);
    }
}
