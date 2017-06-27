using System.Web.Mvc;

namespace iLend.Controllers
{
    public class HandoversController : Controller
    {
        // GET: Handovers
        public ActionResult New()
        {
            return View();
        }
    }
}