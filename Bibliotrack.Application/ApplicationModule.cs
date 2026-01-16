using Bibliotrack.Application.Commands.BookCommands.AddBook;
using Bibliotrack.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bibliotrack.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddValidation()
                .AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services
                .AddMediatR(config => config.RegisterServicesFromAssemblyContaining<AddBookCommand>());

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<AddLoanValidator>();

            return services;
        }
    }
}
