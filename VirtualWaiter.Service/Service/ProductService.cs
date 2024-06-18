using Microsoft.EntityFrameworkCore;
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
            return await _virtualWaiterContext.Product.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _virtualWaiterContext.Product.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<bool> Save(Product product)
        {
            _virtualWaiterContext.Product.Add(product);
            await _virtualWaiterContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Update(Product product)
        {
            var existingProduct = await _virtualWaiterContext.Product.FirstOrDefaultAsync(x => x.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Active = product.Active;

                _virtualWaiterContext.Product.Update(existingProduct);
                await _virtualWaiterContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var existingProduct = await _virtualWaiterContext.Product.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Active = (sbyte?)(existingProduct.Active == 1 ? 0 : 1);
                _virtualWaiterContext.Product.Update(existingProduct);
                await _virtualWaiterContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
