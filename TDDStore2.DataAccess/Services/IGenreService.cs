using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;

namespace TDDStore2.DataAccess.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task<Genre> GetGenre(int id);
        Task<Genre> CreateGenre(Genre genre);
        Task<Genre> UpdateGenre(int id, Genre genre);
        void DeleteGenre(int id);
    }
}
