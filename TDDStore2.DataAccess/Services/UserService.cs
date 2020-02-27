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
    public class UserService : IUserService
    {
        public async Task<ApplicationUser> CreateUser(UserViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/users");
                var str = JsonConvert.SerializeObject(model);
                var strContent = new StringContent(str, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(client.BaseAddress, strContent);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error creating user");
                var strToReturn = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<ApplicationUser>(strToReturn);
                return user;
            }
        }

        public async void DeleteUser(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/users/" + id);
                var response = await client.DeleteAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error deleting user");
            }
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/users/" + id);
                var response = await client.GetAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error fetching user with id: " + id);
                var str = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<ApplicationUser>(str);
                return user;
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/users");
                var response = await client.GetAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error fetching users");
                var str = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<IEnumerable<ApplicationUser>>(str);
                return users;
            }
        }

        public async Task<ApplicationUser> UpdateUser(string id, UserViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/users" + id);
                var str = JsonConvert.SerializeObject(model);
                var strContent = new StringContent(str, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(client.BaseAddress, strContent);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error updatig user with id: " + id);
                var strToReturn = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<ApplicationUser>(strToReturn);
                return user;
            }
        }
    }
}
