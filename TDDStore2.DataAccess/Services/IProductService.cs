using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;

namespace TDDStore2.DataAccess.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task<Product> DeleteProduct(int id);
    }
}
