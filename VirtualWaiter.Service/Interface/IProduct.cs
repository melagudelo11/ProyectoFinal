using VirtualWaiter.Service.Data.Models;

namespace VirtualWaiter.Service.Interface
{
    public interface IProduct
    {
        public Task<IEnumerable<Product>> GetActive();
        public Task<bool> Save(Product product);
        public Task<Product> GetById(int id);
        public Task<bool> Update(Product product);
        Task<bool> Delete(int id);
    }
}
