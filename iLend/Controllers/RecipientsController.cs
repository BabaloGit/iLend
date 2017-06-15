using iLend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace iLend.Controllers
{
    public class RecipientsController : Controller
    {
        // GET: Recipients
        public ViewResult Index()
        {
            var recipients = GetRecepients();

            return View(recipients);
        }

        public ActionResult Details(int id)
        {
            var recipient = GetRecepients().SingleOrDefault(r => r.Id == id);

            if (recipient == null)
                return HttpNotFound();

            return View(recipient);
        }

        private IEnumerable<Recipient> GetRecepients()
        {
            return new List<Recipient>()
            {
                new Recipient() { Id = 1, Name = "Fellow Mtshali" },
                new Recipient() { Id = 2, Name = "Olwethu Ngobese" }
            };
        }
    }
}