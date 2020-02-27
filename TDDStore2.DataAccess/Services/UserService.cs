using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDDStore2.DataAccess.Models;

namespace TDDStore2.DataAccess.Services
{
    public class UserService : IUserService
    {
        public Task<ApplicationUser> CreateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> UpdateUser(string id, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
