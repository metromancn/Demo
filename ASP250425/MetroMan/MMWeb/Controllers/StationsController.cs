using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMWeb.Controllers
{
    public class StationsController : Controller
    {
        // cities/{city}/stations/{station}
        public ActionResult Detail(string city, string station)
        {
            return View();
        }
    }
}