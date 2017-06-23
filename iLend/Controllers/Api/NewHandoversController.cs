using iLend.Models;
using iLend.Models.Dtos;
using System;
using System.Linq;
using System.Web.Http;

namespace iLend.Controllers.Api
{
    public class NewHandoversController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NewHandoversController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult CreateNewHandOver(NewHandOverDto newHandOver)
        {
            var recipient = _context.Recipients.Single(
                r => r.Id == newHandOver.RecipentId);

            var products = _context.Products.Where(
                p => newHandOver.ProductIds.Contains(p.Id)).ToList();

            foreach (var product in products)
            {
                if (product.NumberAvailable == 0)
                    return BadRequest("Product is nor available.");

                product.NumberAvailable--;

                var handOver = new HandOver()
                {
                    Recipient = recipient,
                    Product = product,
                    DateHandedOver = DateTime.Now
                };

                _context.HandOvers.Add(handOver);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
