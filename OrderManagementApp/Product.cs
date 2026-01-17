using System.ComponentModel.DataAnnotations;

namespace baithi.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Product Name must be between 2 and 200 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "SKU is required")]
        [StringLength(50, ErrorMessage = "SKU must be less than 50 characters")]
        public required string Sku { get; set; }

        [StringLength(500, ErrorMessage = "Description must be less than 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public required decimal Price { get; set; }

        [Required(ErrorMessage = "Stock Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock Quantity cannot be negative")]
        public required int StockQuantity { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(100, ErrorMessage = "Category must be less than 100 characters")]
        public required string Category { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property: một Product có thể có nhiều Orders
        public ICollection<Order>? Orders { get; set; }
    }
}