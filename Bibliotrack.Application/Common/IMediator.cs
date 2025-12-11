namespace Bibliotrack.Application.Common
{
    public interface IMediator
    {
        Task<TResponse> DispatchAsync<TRequest, TResponse>(TRequest request);
    }
}
