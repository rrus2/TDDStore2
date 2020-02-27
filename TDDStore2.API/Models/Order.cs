using System;
using System.Collections.Generic;
using System.Text;

namespace TDDStore2.API.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
