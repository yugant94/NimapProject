using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NimapProject.Models
{
    public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetCategories(int page, int pageSize, out int totalCategories)
    {
        totalCategories = _context.Categories.Count();
        return _context.Categories.OrderBy(c => c.CategoryId)
                                  .Skip((page - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();
    }

    public Category GetCategoryById(int id)
    {
        return _context.Categories.Find(id);
    }

    public bool AddCategory(Category category)
    {
        if (IsCategoryExists(category.CategoryName))
            return false;

        _context.Categories.Add(category);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateCategory(Category category)
    {
        var existing = _context.Categories.Find(category.CategoryId);
        if (existing == null || IsCategoryExists(category.CategoryName))
            return false;

        existing.CategoryName = category.CategoryName;
        _context.SaveChanges();
        return true;
    }

    public bool DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
            return false;

        _context.Categories.Remove(category);
        _context.SaveChanges();
        return true;
    }

    public bool IsCategoryExists(string categoryName)
    {
        return _context.Categories.Any(c => c.CategoryName == categoryName);
    }
}

}