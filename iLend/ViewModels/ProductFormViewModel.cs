using iLend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iLend.ViewModels
{
    public class ProductFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category")]
        public byte CategoryId { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, Int32.MaxValue, ErrorMessage = "There should be at least 1 item in stock.")]
        public byte NumberInStock { get; set; }

        public string Title => Id != 0 ? "Edit Product" : "New Product";

        public ProductFormViewModel()
        {
            Id = 0;
        }

        public ProductFormViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            CategoryId = product.CategoryId;
            NumberInStock = product.NumberInStock;
        }
    }
}