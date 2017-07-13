using System;
using System.ComponentModel.DataAnnotations;

namespace iLend.Models.Dtos
{
    public class HandoverDto
    {
        public int Id { get; set; }

        [Required]
        public RecipientDto Recipient { get; set; }

        [Required]
        public ProductDto Product { get; set; }

        public DateTime DateHandedOver { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}