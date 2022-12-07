using MediatR;
using WebAPI.Behaviours;

namespace WebAPI.Features.Products.Queries.GetListProduct
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>, ICachableRequest
    {
        public bool BypassCache { get; set; } = false;
        public string CacheKey { get; set; } = "GetAllProductQueryRequest";
        public TimeSpan? SlidingExpiration { get; set; } = TimeSpan.FromSeconds(30);
    }
}
