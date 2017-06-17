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
            var viewModel = new NewRecipientViewModel()
            {
                UserGroups = userGroups
            };

            return View(viewModel);
        }

        public ActionResult Create(Recipient recipient)
        {
            _context.Recipients.Add(recipient);
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
    }
}