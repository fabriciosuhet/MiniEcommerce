using Auth.API.Entities;
using Auth.API.Infrastructure;
using Auth.API.Repositories.Interfaces;

namespace Auth.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;
        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
