using System;
using System.Collections.Generic;
using System.Text;

namespace TDDStore2.API.Models
{
    public class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
