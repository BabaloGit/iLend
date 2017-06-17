using iLend.Models;
using iLend.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace iLend.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var products = _context.Products.Include(p => p.Category).ToList();

            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
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