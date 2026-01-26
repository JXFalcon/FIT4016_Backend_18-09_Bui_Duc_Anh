// File: Category.cs
using System.ComponentModel.DataAnnotations;

namespace Categories.Models;

public class Category
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name không được trống")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name phải từ 3-100 ký tự")]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}