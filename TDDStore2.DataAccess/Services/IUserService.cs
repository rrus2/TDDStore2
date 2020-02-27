using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;

namespace TDDStore2.DataAccess.Services
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUser(string id);
        Task<ApplicationUser> CreateUser(ApplicationUser user);
        Task<ApplicationUser> UpdateUser(string id, ApplicationUser user);
        void DeleteUser(string id);
    }
}
