using iLend.Models;
using iLend.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace iLend.Controllers
{
    public class ProductsController : Controller
    {
        public ViewResult Index()
        {
            var products = GetProducts();

            return View(products);
        }

        public IEnumerable<Product> GetProducts()
        {
            return  new List<Product>()
            {
                new Product() { Id = 1, Name = "Network Cable" },
                new Product() { Id = 2, Name = "Lenovo Notebook PC" }
            };
        }
        
        // GET: Products/Random
        public ActionResult Random()
        {
            var product =  new Product() { Name = "Acer Monitor" };
            var recipients = new List<Recipient>()
            {
                new Recipient() { Name = "Recipient 1" },
                new Recipient() { Name = "Recipient 2" }
            };

            var viewModel = new RandomProductViewModel()
            {
                Product = product,
                Recipients = recipients
            };

            return View(viewModel);
        }
    }
}