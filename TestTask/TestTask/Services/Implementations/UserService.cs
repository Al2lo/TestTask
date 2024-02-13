using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public Task<User> GetUser()
        {
            return _context.Users.OrderByDescending(x => x.Orders.Count()).FirstOrDefaultAsync(); ;
        }

        public Task<List<User>> GetUsers()
        {
            return _context.Users.Where(a => a.Status.Equals(Enums.UserStatus.Inactive)).ToListAsync(); ;
        }
    }
}
