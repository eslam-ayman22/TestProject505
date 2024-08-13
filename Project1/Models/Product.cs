using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [RegularExpression(@"[0-9]+\-(jpg | png)")]
       
        public string Img { get; set; }
        [Range(1,500000)]
        public double Price { get; set; }
        [Range(1 ,5)]
        public int Rate { get; set; }

        [ValidateNever]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
