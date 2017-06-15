using iLend.Models;
using System.Collections.Generic;

namespace iLend.ViewModels
{
    public class RandomProductViewModel
    {
        public Product Product { get; set; }
        public List<Recipient> Recipients { get; set; }
    }
}