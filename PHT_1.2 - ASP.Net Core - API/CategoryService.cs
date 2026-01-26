// File: Services/CategoryService.cs
using Categories.Models;

namespace Categories.Services;

public class CategoryService : ICategoryService
{
    private readonly List<Category> _categories = new()
    {
        new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and gadgets", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-10) },
        new Category { Id = 2, Name = "Books", Description = "All kinds of books", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-5) },
        new Category { Id = 3, Name = "Clothing", Description = "Fashion and clothing items", IsActive = true, CreatedAt = DateTime.UtcNow.AddDays(-2) }
    };

    public List<Category> GetAllCategories() => _categories;

    public Category? GetCategoryById(int id) => _categories.FirstOrDefault(c => c.Id == id);

    public Category CreateCategory(Category category)
    {
        category.Id = _categories.Count > 0 ? _categories.Max(c => c.Id) + 1 : 1;
        category.CreatedAt = DateTime.UtcNow;
        _categories.Add(category);
        return category;
    }

    public Category? UpdateCategory(int id, Category category)
    {
        var existingCategory = GetCategoryById(id);
        if (existingCategory == null) return null;

        existingCategory.Name = category.Name;
        existingCategory.Description = category.Description;
        existingCategory.IsActive = category.IsActive;
        
        return existingCategory;
    }

    public bool DeleteCategory(int id)
    {
        var category = GetCategoryById(id);
        if (category == null) return false;
        
        return _categories.Remove(category);
    }
}