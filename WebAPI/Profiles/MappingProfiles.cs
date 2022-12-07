using AutoMapper;
using WebAPI.Entities;
using WebAPI.Features.Products.Commands.CreateCreateOrderCommandRequestProduct;
using WebAPI.Features.Products.Queries.GetListProduct;

namespace WebAPI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, GetAllProductQueryResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
        }
    }
}
