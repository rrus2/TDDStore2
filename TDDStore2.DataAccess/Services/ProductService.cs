using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;

namespace TDDStore2.DataAccess.Services
{
    public class ProductService : IProductService
    {
        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
