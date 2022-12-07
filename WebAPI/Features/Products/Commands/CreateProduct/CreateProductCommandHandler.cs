using AutoMapper;
using MediatR;
using WebAPI.Entities;
using WebAPI.Features.Products.Commands.CreateCreateOrderCommandRequestProduct;
using WebAPI.Repository;

namespace WebAPI.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product mappedProduct = _mapper.Map<Product>(request);
            _productRepository.Add(mappedProduct);
            return Task.FromResult(new CreateProductCommandResponse());
        }
    }
}
