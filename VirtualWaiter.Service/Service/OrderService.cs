using Microsoft.EntityFrameworkCore;
using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Interface;

namespace VirtualWaiter.Service.Service
{
    public class OrderService: IOrder
    {
        private readonly VirtualWaiterContext _virtualWaiterContext;

        public OrderService(VirtualWaiterContext virtualWaiterContext)
        {
            _virtualWaiterContext = virtualWaiterContext;
        }


        public async Task<IEnumerable<Order>> GetActive()
        {
            return await _virtualWaiterContext.Order.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _virtualWaiterContext.Order.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> Save(Order order)
        {
           try
            {
                _virtualWaiterContext.Order.Add(order);
                await _virtualWaiterContext.SaveChangesAsync();
            }
            catch (Exception ex) {

                Console.WriteLine(ex);
            
            }
            
           

            return true;

        }

        public async Task<bool> Update(Order order)
        {
            var existingOrder = await _virtualWaiterContext.Order.FirstOrDefaultAsync(x => x.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.IdUser = order.IdUser;
                existingOrder.IdEaterytable = order.IdEaterytable;
                existingOrder.CreationDate = order.CreationDate;
                existingOrder.Observation = order.Observation;
                existingOrder.Price = order.Price;
                existingOrder.Active = order.Active;

                _virtualWaiterContext.Order.Update(existingOrder);
                await _virtualWaiterContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var existingOrder = await _virtualWaiterContext.Order.FirstOrDefaultAsync(x => x.Id == id);
            if (existingOrder != null)
            {
                existingOrder.Active = (sbyte?)(existingOrder.Active == 1 ? 0 : 1);
                _virtualWaiterContext.Order.Update(existingOrder);
                await _virtualWaiterContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
