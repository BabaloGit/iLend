using iLend.Models;
using System.Collections.Generic;

namespace iLend.ViewModels
{
    public class ProductFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; }

        public string Title
        {
            get
            {
                if (Product != null && Product.Id != 0)
                    return "Edit Product";

                return "New Product";
            }
        }
    }
}