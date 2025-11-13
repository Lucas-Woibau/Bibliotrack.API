using Bibliotrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bibliotrack.Infrastructure.Persistence
{
    public class BibliotrackDbContext : DbContext
    {
        public BibliotrackDbContext(DbContextOptions<BibliotrackDbContext> options) : base(options) { }

        public DbSet<Book>  Books { get; set; }
        public  DbSet<User> Users{ get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
