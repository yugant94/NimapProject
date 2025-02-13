using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimapProject.Models
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(int page, int pageSize, out int totalProducts);
        Product GetProductById(int id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        bool IsProductExists(string productName);
    }


}
