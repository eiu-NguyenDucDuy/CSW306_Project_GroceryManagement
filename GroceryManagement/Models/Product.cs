using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string? ThumbnailUrl { get; set; }

        public string? Description { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        //Navigation property
        public Category? Category { get; set; }

        public Supplier? Supplier { get; set; }
    }
}
