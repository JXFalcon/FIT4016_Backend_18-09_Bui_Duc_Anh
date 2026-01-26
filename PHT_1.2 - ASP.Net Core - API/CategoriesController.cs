// File: Controllers/CategoriesController.cs
using Microsoft.AspNetCore.Mvc;
using Categories.Models;
using Categories.Services;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/categories
    // GET: api/categories?name=electronics
    // GET: api/categories?page=1&pageSize=2
    [HttpGet]
    public ActionResult<List<Category>> GetAll(string? name = null, int page = 1, int pageSize = 10)
    {
        var categories = _categoryService.GetAllCategories();
        
        if (!string.IsNullOrEmpty(name))
        {
            categories = categories.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                                   .ToList();
        }
        
        // Pagination
        var paginated = categories.Skip((page - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();
        
        return Ok(paginated);
    }

    // GET: api/categories/{id}
    [HttpGet("{id}")]
    public ActionResult<Category> GetById(int id)
    {
        var category = _categoryService.GetCategoryById(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    // POST: api/categories
    [HttpPost]
    public ActionResult<Category> Create(Category category)
    {
        var createdCategory = _categoryService.CreateCategory(category);
        return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
    }

    // PUT: api/categories/{id}
    [HttpPut("{id}")]
    public ActionResult<Category> Update(int id, Category category)
    {
        var updatedCategory = _categoryService.UpdateCategory(id, category);
        if (updatedCategory == null) return NotFound();
        return Ok(updatedCategory);
    }

    // DELETE: api/categories/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _categoryService.DeleteCategory(id);
        if (!result) return NotFound();
        return NoContent();
    }
}