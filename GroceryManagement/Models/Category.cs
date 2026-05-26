using System.ComponentModel.DataAnnotations;

namespace GroceryManagement.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        // Navigation property
        public ICollection<Product>? Products { get; set; }
    }
}
