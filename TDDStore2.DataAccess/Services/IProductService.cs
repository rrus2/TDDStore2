using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;
using TDDStore2.DataAccess.VIewModels;

namespace TDDStore2.DataAccess.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> CreateProduct(ProductViewModel product);
        Task<Product> UpdateProduct(int id, ProductViewModel product);
        void DeleteProduct(int id);
    }
}
