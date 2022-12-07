using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    [Table("products")]
    public class Product
    {
        [Column("product_id")]
        public int Id { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("quantity_per_unit")]
        public string QuantityPerUnit { get; set; }

        [Column("unit_price")]
        public double UnitPrice { get; set; }
    }
}
