using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;
using TDDStore2.DataAccess.VIewModels;

namespace TDDStore2.DataAccess.Services
{
    public class ProductService : IProductService
    {
        public async Task<Product> CreateProduct(ProductViewModel model)
        {
            var product = new Product { Name = model.Name, Price = model.Price, Stock = model.Stock, GenreID = model.GenreID };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/products");
                var str = JsonConvert.SerializeObject(product);
                var strContent = new StringContent(str, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(client.BaseAddress, strContent);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error creating new product");
                return product;
            }
        }

        public async void DeleteProduct(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/products/" + id);
                var response = await client.DeleteAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error deleting product");
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/products/" + id);
                var response = await client.GetAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error fetching product with id: " + id);
                var str = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(str);
                return product;
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/products");
                var response = await client.GetAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error fetching products");
                var str = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(str);
                return products;
            }
        }

        public async Task<Product> UpdateProduct(int id, ProductViewModel model)
        {
            var product = new Product { Name = model.Name, Price = model.Price, Stock = model.Stock, GenreID = model.GenreID };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/products/" + id);
                var str = JsonConvert.SerializeObject(product);
                var strContent = new StringContent(str, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(client.BaseAddress, strContent);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error updating product with id: " + id);
                return product;
            }
        }
    }
}
