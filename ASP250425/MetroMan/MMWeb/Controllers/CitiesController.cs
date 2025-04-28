using System.Web.Mvc;

namespace MMWeb.Controllers
{
    public class CitiesController : Controller
    {
        // /cities/
        public ActionResult Index()
        {
            return View();
        }

        // /cities/{slug}
        public ActionResult Detail(string slug)
        {
            return View();
        }
    }
}
