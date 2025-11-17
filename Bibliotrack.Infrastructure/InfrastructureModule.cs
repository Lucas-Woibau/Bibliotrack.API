using Bibliotrack.Domain.Repositories;
using Bibliotrack.Infrastructure.Persistence;
using Bibliotrack.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bibliotrack.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddData(configuration)
                .AddRepositories();

            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BibliotrackCS");

            services.AddDbContext<BibliotrackDbContext>(
                options => options.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<ILoanRepository, LoanRepository>()
                .AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
