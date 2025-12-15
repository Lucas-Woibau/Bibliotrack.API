using Bibliotrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibliotrack.Infrastructure.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(e => e.Book)
                    .WithMany()
                    .HasForeignKey(e => e.IdBook);

            builder.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}
