using Microsoft.Extensions.DependencyInjection;

namespace Bibliotrack.Application.Common
{
    internal class Mediator : IMediator
    {
        readonly IServiceScopeFactory _factory;

        public Mediator(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public async Task<TResponse> DispatchAsync<TRequest, TResponse>(TRequest request)
        {
            var scope = _factory.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<IHandler<TRequest, TResponse>>();

            return await handler.HandleAsync(request);
        }
    }
}
