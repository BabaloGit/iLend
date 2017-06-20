using System;
using System.ComponentModel.DataAnnotations;

namespace iLend.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte CategoryId { get; set; }

        public DateTime DateAdded { get; set; }
        
        [Range(1, Int32.MaxValue, ErrorMessage = "There should be at least 1 item in stock.")]
        public byte NumberInStock { get; set; }
    }
}