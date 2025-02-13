using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NimapProject.Models
{
   public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetProducts(int page, int pageSize, out int totalProducts)
    {
        totalProducts = _context.Products.Count();
        return _context.Products.Include("Category")
                                .OrderBy(p => p.ProductId)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
    }

    public Product GetProductById(int id)
    {
        return _context.Products.Find(id);
    }

    public bool AddProduct(Product product)
    {
        if (IsProductExists(product.ProductName))
            return false;

        _context.Products.Add(product);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateProduct(Product product)
    {
        var existing = _context.Products.Find(product.ProductId);
        if (existing == null || IsProductExists(product.ProductName))
            return false;

        existing.ProductName = product.ProductName;
        existing.CategoryId = product.CategoryId;
        _context.SaveChanges();
        return true;
    }

    public bool DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
            return false;

        _context.Products.Remove(product);
        _context.SaveChanges();
        return true;
    }

    public bool IsProductExists(string productName)
    {
        return _context.Products.Any(p => p.ProductName == productName);
    }
}

}