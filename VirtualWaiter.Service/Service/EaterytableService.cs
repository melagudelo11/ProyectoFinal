using Microsoft.EntityFrameworkCore;
using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Interface;

namespace VirtualWaiter.Service.Service
{
    public class EaterytableService: IEaterytable
    {
        private readonly VirtualWaiterContext _virtualWaiterContext;

        public EaterytableService(VirtualWaiterContext virtualWaiterContext)
        {
            _virtualWaiterContext = virtualWaiterContext;
        }


        public async Task<IEnumerable<Eaterytable>> GetActive()
        {
            return await _virtualWaiterContext.Eaterytable.ToListAsync();
        }

        public async Task<Eaterytable> GetById(int id)
        {
            return await _virtualWaiterContext.Eaterytable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Save(Eaterytable eaterytable)
        {
            _virtualWaiterContext.Eaterytable.Add(eaterytable);
            await _virtualWaiterContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Update(Eaterytable eaterytable)
        {
            var existingEaterytable = await _virtualWaiterContext.Eaterytable.FirstOrDefaultAsync(x => x.Id == eaterytable.Id);
            if (existingEaterytable != null)
            {
                existingEaterytable.Number = eaterytable.Number;
                existingEaterytable.Capacity = eaterytable.Capacity;
                existingEaterytable.Active = eaterytable.Active;

                _virtualWaiterContext.Eaterytable.Update(existingEaterytable);
                await _virtualWaiterContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var existingEaterytable = await _virtualWaiterContext.Eaterytable.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEaterytable != null)
            {
                existingEaterytable.Active = (sbyte?)(existingEaterytable.Active == 1 ? 0 : 1);
                _virtualWaiterContext.Eaterytable.Update(existingEaterytable);
                await _virtualWaiterContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

