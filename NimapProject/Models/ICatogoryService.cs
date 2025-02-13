using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NimapProject.Models
{

    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(int page, int pageSize, out int totalCategories);
        Category GetCategoryById(int id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        bool IsCategoryExists(string categoryName);
    }


}