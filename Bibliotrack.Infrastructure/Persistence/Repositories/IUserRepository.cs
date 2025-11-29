using Bibliotrack.Domain.Entities;

namespace Bibliotrack.Infrastructure.Auth
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string userEmail);
    }
}
