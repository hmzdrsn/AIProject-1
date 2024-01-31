using AIProject.Application.Common.Interfaces;
using AIProject.Domain.Abstraction;
using AIProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Infrastructure.Persistance.Services
{
    //AYAR CEKİLECEK MAPPING,UPDATE EDERKEN UPDATE METODU
    public class UserService : BaseService<User>, IUserService
    {
        private readonly ApplicationContext _context;
        public UserService(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            await Table.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(User user)
        {
            var removeItem = Table.FirstOrDefault(e => e.Id == user.Id);
            if(removeItem != null)
            {
                Table.Remove(removeItem);
            }
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var data = await Table.ToListAsync();
            return data;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var data =await Table.FindAsync(id);
            return data;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var data = await Table.Where(e => e.Email == email).FirstOrDefaultAsync();
            return data;
        }

        public async Task<User> UpdateAsync(User user)
        {

            var Item = Table.FirstOrDefault(e => e.Id == user.Id);
            if (Item != null)
            {
                Table.Update(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }
    }
}
