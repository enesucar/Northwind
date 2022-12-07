using MediatR;
using WebAPI.Caching;

namespace WebAPI.Behaviours
{
    public class CachingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>, ICachableRequest
    {
        private readonly ICacheManager _cache;

        public CachingBehaviour(ICacheManager cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;

            if (request.BypassCache)
            {
                return await next();
            }

            if (_cache.Contains(request.CacheKey))
            {
                response = _cache.Get<TResponse>(request.CacheKey);
            }
            else
            {
                response = await next();
                _cache.Set(request.CacheKey, response, 1);
            }

            return response;
        }
    }
}
