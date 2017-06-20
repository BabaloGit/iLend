using AutoMapper;
using iLend.Models;
using iLend.Models.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace iLend.Controllers.Api
{
    public class RecipientsController : ApiController
    {
        private ApplicationDbContext _context;

        public RecipientsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/recipients
        public IEnumerable<RecipientDto> GetRecipients()
        {
            return Mapper.Map<IEnumerable<RecipientDto>>(_context.Recipients.ToList());
        }

        // GET /api/recipients/1
        public RecipientDto GetRecipient(int id)
        {
            var recipient = _context.Recipients.SingleOrDefault(r => r.Id == id);

            if (recipient == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<RecipientDto>(recipient);
        }

        // POST /api/recipients
        [HttpPost]
        public RecipientDto CreateRecipient(RecipientDto recipientDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var recipient = Mapper.Map<Recipient>(recipientDto);

            _context.Recipients.Add(recipient);
            _context.SaveChanges();

            recipientDto.Id = recipient.Id;

            return recipientDto;
        }

        // PUT /api/recipients/1
        [HttpPut]
        public void UpdateRecipient(int id, RecipientDto recipientDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var recipientInDb = _context.Recipients.SingleOrDefault(r => r.Id == id);

            if (recipientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(recipientDto, recipientInDb);

            _context.SaveChanges();
        }


        // DELETE /api/recipients/1
        [HttpDelete]
        public void DeleteRecipient(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var recipientInDb = _context.Recipients.SingleOrDefault(r => r.Id == id);

            if (recipientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Recipients.Remove(recipientInDb);
            _context.SaveChanges();
        }
    }
}
