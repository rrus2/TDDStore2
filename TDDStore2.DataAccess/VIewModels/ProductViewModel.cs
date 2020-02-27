using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TDDStore2.DataAccess.VIewModels
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Product name")]
        public string Name { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Stock { get; set; }
        [Required]
        public int GenreID { get; set; }
    }
}
