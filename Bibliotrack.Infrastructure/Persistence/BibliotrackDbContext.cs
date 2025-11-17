using Bibliotrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bibliotrack.Infrastructure.Persistence
{
    public class BibliotrackDbContext : DbContext
    {
        public BibliotrackDbContext(DbContextOptions<BibliotrackDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(e =>
            {
                e.HasKey(e => e.Id);

                e.Property(b => b.Status)
                    .HasConversion<string>();
            });

            builder.Entity<Loan>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(e => e.Book)
                    .WithMany()
                    .HasForeignKey(e => e.IdBook);
            });

            builder.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);
            });

            base.OnModelCreating(builder);
        }
    }
}
