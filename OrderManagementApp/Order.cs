using System.ComponentModel.DataAnnotations;

namespace baithi.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Order Number is required")]
        [RegularExpression(@"^ORD-\d{8}-\d{4}$", ErrorMessage = "Order Number format must be ORD-YYYYMMDD-XXXX")]
        public required string OrderNumber { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Customer Name must be between 2 and 100 characters")]
        public required string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }

        // Navigation property không cần required, EF sẽ gán khi load dữ liệu
        public Product? Product { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public required int Quantity { get; set; }

        [Required(ErrorMessage = "Order Date is required")]
        [DataType(DataType.Date)]
        public required DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeliveryDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}