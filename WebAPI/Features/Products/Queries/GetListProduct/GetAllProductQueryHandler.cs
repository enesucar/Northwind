using AutoMapper;
using MediatR;
using System.Collections.Generic;
using WebAPI.Repository;

namespace WebAPI.Features.Products.Queries.GetListProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        
        public GetAllProductQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetList();
            var mappedProducts = _mapper.Map<List<GetAllProductQueryResponse>>(products);
            return Task.FromResult(mappedProducts);
        }
    }
}
