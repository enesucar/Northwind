using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Entities;

namespace WebAPI.Features.Products.Queries.GetListProduct
{
    public class GetAllProductQueryResponse
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
    }
}
