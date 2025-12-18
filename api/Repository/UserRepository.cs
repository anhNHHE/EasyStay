using api.Interface.Repositories;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EasyStayContext _context;


        public UserRepository(EasyStayContext context)
        {
            _context = context;
        }


        public async Task<User?> GetByIdAsync(Guid id)
        => await _context.Users.FindAsync(id);


        public async Task<User?> GetByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);


        public async Task<List<User>> GetAllAsync()
        => await _context.Users.ToListAsync();


        public async Task AddAsync(User user)
        => await _context.Users.AddAsync(user);


        public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
    }
}