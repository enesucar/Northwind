using Microsoft.EntityFrameworkCore;
using WebAPI.Data.EntityFramework;
using WebAPI.Entities;
using WebAPI.Repository.EntityFramework.Contexts;

namespace WebAPI.Repository.EntityFramework
{
    public class EfProductRepository : EfRepositoryBase<Product, NorthwindContext>, IProductRepository
    {
    }
}
