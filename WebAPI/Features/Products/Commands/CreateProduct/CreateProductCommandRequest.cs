using MediatR;
using WebAPI.Features.Products.Commands.CreateProduct;

namespace WebAPI.Features.Products.Commands.CreateCreateOrderCommandRequestProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
    }
}
