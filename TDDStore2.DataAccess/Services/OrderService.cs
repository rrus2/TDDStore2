using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;

namespace TDDStore2.DataAccess.Services
{
    public class OrderService : IOrderService
    {
        public async Task<Order> CreateOrder(Order order)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/orders");
                var str = JsonConvert.SerializeObject(order);
                var strContent = new StringContent(str, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(client.BaseAddress, strContent);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error creating order");
                var strToReturn = await response.Content.ReadAsStringAsync();
                var orderToReturn = JsonConvert.DeserializeObject<Order>(strToReturn);
                return orderToReturn;
            }
        }

        public async void DeleteOrder(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/orders/" + id);
                var response = await client.DeleteAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error deleting product with id: " + id);
            }
        }

        public async Task<Order> GetOrder(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/orders/" + id);
                var response = await client.GetAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error fetching order with id: " + id);
                var str = await response.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<Order>(str);
                return order;
            }
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/orders");
                var response = await client.GetAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error fetching orders");
                var str = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(str);
                return orders;
            }
        }

        public async Task<Order> UpdateOrder(int id, Order order)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/orders/" + id);
                var str = JsonConvert.SerializeObject(order);
                var strContent = new StringContent(str, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(client.BaseAddress, strContent);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error updating order with id: " + id);
                var strToReturn = await response.Content.ReadAsStringAsync();
                var orderToReturn = JsonConvert.DeserializeObject<Order>(strToReturn);
                return orderToReturn;
            }
        }
    }
}
