using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task EditUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
