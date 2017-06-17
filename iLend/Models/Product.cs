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
        public byte CategoryId { get; set; }
        public DateTime DateAdded { get; set; }
        public byte NumberInStock { get; set; }

    }
}