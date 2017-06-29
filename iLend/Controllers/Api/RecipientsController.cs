using AutoMapper;
using iLend.Models;
using iLend.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace iLend.Controllers.Api
{
    public class RecipientsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RecipientsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/recipients
        public IHttpActionResult GetRecipients(string query)
        {
            var recipientsQuery = _context.Recipients
                .Include(r => r.UserGroup);

            if (!String.IsNullOrWhiteSpace(query))
                recipientsQuery = recipientsQuery.Where(r => r.Name.Contains(query));

            return Ok(Mapper.Map<IEnumerable<RecipientDto>>(recipientsQuery
                .ToList()));
        }

        // GET /api/recipients/1
        public IHttpActionResult GetRecipient(int id)
        {
            var recipient = _context.Recipients
                .Include(r => r.UserGroup)
                .SingleOrDefault(r => r.Id == id);

            if (recipient == null)
                return NotFound();

            return Ok(Mapper.Map<RecipientDto>(recipient));
        }

        // POST /api/recipients
        [HttpPost]
        public IHttpActionResult CreateRecipient(RecipientDto recipientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipient = Mapper.Map<Recipient>(recipientDto);

            _context.Recipients.Add(recipient);
            _context.SaveChanges();

            recipientDto.Id = recipient.Id;

            return Created(new Uri(Request.RequestUri + "/" + recipient.Id), recipientDto);
        }

        // PUT /api/recipients/1
        [HttpPut]
        public IHttpActionResult UpdateRecipient(int id, RecipientDto recipientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipientInDb = _context.Recipients.SingleOrDefault(r => r.Id == id);

            if (recipientInDb == null)
                return NotFound();

            Mapper.Map(recipientDto, recipientInDb);

            _context.SaveChanges();

            return Ok();
        }


        // DELETE /api/recipients/1
        [HttpDelete]
        public IHttpActionResult DeleteRecipient(int id)
        {
            var recipientInDb = _context.Recipients.SingleOrDefault(r => r.Id == id);

            if (recipientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Recipients.Remove(recipientInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
