using System;
using System.ComponentModel.DataAnnotations;

namespace iLend.Models
{
    public class HandOver
    {
        public int Id { get; set; }

        [Required]
        public Recipient Recipient { get; set; }

        [Required]
        public Product Product { get; set; }

        public DateTime DateHandedOver { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}