using Microsoft.EntityFrameworkCore;
using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Interface;

namespace VirtualWaiter.Service.Service
{
    public class UserService: IUser
    {

        private readonly VirtualWaiterContext _virtualWaiterContext;

        public UserService(VirtualWaiterContext virtualWaiterContext)
        {
            _virtualWaiterContext = virtualWaiterContext;
        }


        public async Task<IEnumerable<User>> GetActive()
        {
            return await _virtualWaiterContext.User.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _virtualWaiterContext.User.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> Save(User user)
        {
            _virtualWaiterContext.User.Add(user);
            await _virtualWaiterContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Update(User user)
        {
            var existingUser = await _virtualWaiterContext.User.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.RoleCode = user.RoleCode;
                existingUser.Name = user.Name;
                existingUser.LastName = user.LastName;
                existingUser.Identification = user.Identification;
                existingUser.Birthday = user.Birthday;
                existingUser.Phone = user.Phone;
                existingUser.Email = user.Email;
                existingUser.Active = user.Active;

                _virtualWaiterContext.User.Update(existingUser);
                await _virtualWaiterContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var existingUser = await _virtualWaiterContext.User.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser != null)
            {
                existingUser.Active = (sbyte?)(existingUser.Active == 1 ? 0 : 1);
                _virtualWaiterContext.User.Update(existingUser);
                await _virtualWaiterContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

}
