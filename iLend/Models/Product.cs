using System;
using System.ComponentModel.DataAnnotations;

namespace iLend.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Category Category { get; set; }

        [Required]
        [Display(Name = "Category")]
        public byte CategoryId { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
    }
}