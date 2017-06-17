using iLend.Models;
using iLend.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace iLend.Controllers
{
    public class RecipientsController : Controller
    {
        private ApplicationDbContext _context;

        public RecipientsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var userGroups = _context.UserGroups.ToList();
            var viewModel = new RecipientFormViewModel()
            {
                UserGroups = userGroups
            };

            return View("RecipientForm", viewModel);
        }

        public ActionResult Save(Recipient recipient)
        {
            if (recipient.Id == 0)
                _context.Recipients.Add(recipient);

            else
            {
                var recipientInDb = _context.Recipients.Single(r => r.Id == recipient.Id);
                recipientInDb.Name = recipient.Name;
                recipientInDb.BirthDate = recipient.BirthDate;
                recipientInDb.UserGroupId = recipient.UserGroupId;
                recipientInDb.IsSubscibedToNewsletter = recipient.IsSubscibedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Recipients");
        }

        public ViewResult Index()
        {
            var recipients = _context.Recipients.Include(c => c.UserGroup).ToList();

            return View(recipients);
        }

        public ActionResult Details(int id)
        {
            var recipient = _context.Recipients.Include(c => c.UserGroup).SingleOrDefault(r => r.Id == id);

            if (recipient == null)
                return HttpNotFound();

            return View(recipient);
        }

        public ActionResult Edit(int id)
        {
            var recipient = _context.Recipients.SingleOrDefault(r => r.Id == id);

            if (recipient == null)
                return HttpNotFound();

            var viewModel = new RecipientFormViewModel()
            {
                Recipient = recipient,
                UserGroups = _context.UserGroups.ToList()
            };

            return View("RecipientForm", viewModel);
        }
    }
}