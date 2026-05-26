using System.ComponentModel.DataAnnotations;

namespace GroceryManagement.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        // Navigation property
        public ICollection<Product>? Products { get; set; }
    }
}
