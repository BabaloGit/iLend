using iLend.Models;
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
        public IEnumerable<Recipient> GetRecipients()
        {
            return _context.Recipients.ToList();
        }

        // GET /api/recipients/1
        public Recipient GetRecipient(int id)
        {
            var recipient = _context.Recipients.SingleOrDefault(r => r.Id == id);

            if (recipient == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return recipient;
        }

        // POST /api/recipients
        [HttpPost]
        public Recipient CreateRecipient(Recipient recipient)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Recipients.Add(recipient);
            _context.SaveChanges();

            return recipient;
        }

        // PUT /api/recipients/1
        [HttpPut]
        public void UpdateRecipient(int id, Recipient recipient)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var recipientInDb = _context.Recipients.SingleOrDefault(r => r.Id == id);

            if (recipientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            recipientInDb.Name = recipient.Name;
            recipientInDb.BirthDate = recipient.BirthDate;
            recipientInDb.IsSubscibedToNewsletter = recipient.IsSubscibedToNewsletter;
            recipientInDb.UserGroupId = recipient.UserGroupId;

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
