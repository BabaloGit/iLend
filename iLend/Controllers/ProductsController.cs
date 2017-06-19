using iLend.Models;
using iLend.ViewModels;
using System;
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

        public ViewResult New()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new ProductFormViewModel()
            {
                Categories = categories
            };

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel(product)
                {
                    Categories = _context.Categories.ToList()
                };

                return View("ProductForm", viewModel);
            }

            if (product.Id == 0)
            {
                product.DateAdded = DateTime.Now;
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.CategoryId = product.CategoryId;
                productInDb.NumberInStock = product.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
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

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel(product)
            {
                Categories = _context.Categories.ToList()
            };

            return View("ProductForm", viewModel);
        }
    }
}