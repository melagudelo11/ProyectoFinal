using VirtualWaiter.Service.Data.Models;

namespace VirtualWaiter.Service.Interface
{
    public interface IEaterytable
    {
        public Task<IEnumerable<Eaterytable>> GetActive();
        public Task<bool> Save(Eaterytable eaterytable);
        public Task<Eaterytable> GetById(int id);
        public Task<bool> Update(Eaterytable eatertytable);
        Task<bool> Delete(int id);
    }
}
