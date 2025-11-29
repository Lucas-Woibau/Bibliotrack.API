using Bibliotrack.Domain.Entities;
using Bibliotrack.Infrastructure.Auth;
using Microsoft.EntityFrameworkCore;

namespace Bibliotrack.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BibliotrackDbContext _context;

        public UserRepository(BibliotrackDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string userEmail)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.Email == userEmail);

            return user;
        }
    }
}
