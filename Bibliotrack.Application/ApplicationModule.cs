using Bibliotrack.Application.Commands.BookCommands.AddBook;
using Bibliotrack.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bibliotrack.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services
                .AddMediatR(config => config.RegisterServicesFromAssemblyContaining<AddBookCommand>());

            return services;
        }
    }
}
