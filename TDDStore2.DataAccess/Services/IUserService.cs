using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;
using TDDStore2.DataAccess.VIewModels;

namespace TDDStore2.DataAccess.Services
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUser(string id);
        Task<ApplicationUser> CreateUser(UserViewModel model);
        Task<ApplicationUser> UpdateUser(string id, UserViewModel model);
        void DeleteUser(string id);
    }
}
