using AutoMapper;
using iLend.Models;
using iLend.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace iLend.Controllers.Api
{
    public class HandoversController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public HandoversController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetHandovers()
        {
            return Ok(Mapper.Map<IEnumerable<HandoverDto>>(_context.HandOvers
                .Include(h => h.Recipient)
                .Include(h => h.Product)
                .ToList()));
        }

        [HttpPost]
        public IHttpActionResult CreateNewHandOver(NewHandOverDto newHandOver)
        {
            var recipient = _context.Recipients.Single(
                r => r.Id == newHandOver.RecipientId);

            var products = _context.Products.Where(
                p => newHandOver.ProductIds.Contains(p.Id)).ToList();

            foreach (var product in products)
            {
                if (product.NumberAvailable == 0)
                    return BadRequest("Product is not available.");

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
