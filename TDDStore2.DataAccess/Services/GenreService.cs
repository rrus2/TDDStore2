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
        public Task<Genre> CreateGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public void DeleteGenre(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetGenre(int id)
        {
            throw new NotImplementedException();
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

        public Task<Genre> UpdateGenre(int id, Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
