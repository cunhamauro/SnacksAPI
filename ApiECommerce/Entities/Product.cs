using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiECommerce.Entities
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(200)]
        public string? Details { get; set; }

        [Required]
        [StringLength(200)]
        public string? ImageUrl { get; set; }

        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }

        public bool Popular { get; set; }

        public bool BestSeller { get; set; }

        public int Stock { get; set; }

        public bool Available { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public ICollection<OrderDetail>? OrderDetails { get; set; }

        [JsonIgnore]
        public ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }

    }
}