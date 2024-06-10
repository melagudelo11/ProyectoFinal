using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Interface;

namespace VirtualWaiter.Service.Service
{
    public class ProductService : IProduct
    {
        private readonly VirtualWaiterContext _virtualWaiterContext;

        public ProductService(VirtualWaiterContext virtualWaiterContext)
        {
            _virtualWaiterContext = virtualWaiterContext;
        }


        public async Task<IEnumerable<Product>> GetActive()
        {
            return _virtualWaiterContext.Product;
        }

        public async Task<bool> Save(Product product)
        {
            _virtualWaiterContext.Product.Add(product);
            await _virtualWaiterContext.SaveChangesAsync();

            return true;

        }
    }
}
