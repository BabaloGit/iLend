using iLend.Models;
using System.Web.Mvc;

namespace iLend.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Random()
        {
            var product =  new Product() { Name = "Acer Monitor" };

            return View(product);
        }
    }
}