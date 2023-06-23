using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(string userId);
        Task CreateUser(User user);
        Task EditUser(User user);
        Task DeleteUser(string id);
    }
}
