using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;

namespace TDDStore2.DataAccess.Services
{
    public class GenreService : IGenreService
    {
        public async Task<Genre> CreateGenre(Genre genre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/genres");
                var str = JsonConvert.SerializeObject(genre);
                var strContent = new StringContent(str, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(client.BaseAddress, strContent);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error creating genre");
                return genre;
            }
        }

        public async void DeleteGenre(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/genres/" + id);
                var response = await client.DeleteAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error deleting genre");
            }
        }

        public async Task<Genre> GetGenre(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/genres/" + id);
                var response = await client.GetAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error fetching genre with id: " + id);
                var str = await response.Content.ReadAsStringAsync();
                var genre = JsonConvert.DeserializeObject<Genre>(str);
                return genre;
            }
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/genres");
                var response = await client.GetAsync(client.BaseAddress);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error fetching genres");
                var str = await response.Content.ReadAsStringAsync();
                var genres = JsonConvert.DeserializeObject<IEnumerable<Genre>>(str);
                return genres;
            }
        }

        public async Task<Genre> UpdateGenre(int id, Genre genre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62710/api/genres/" + id);
                var str = JsonConvert.SerializeObject(genre);
                var strContent = new StringContent(str, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(client.BaseAddress, strContent);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error updating genre with id: " + id);
                return genre;
            }
        }
    }
}
