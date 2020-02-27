using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDDStore2.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Orders = new HashSet<Order>();
        }
        public DateTime Birthdate { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
