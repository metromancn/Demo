using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMWeb.Controllers
{
    public class MapsController : Controller
    {
        // GET: Maps
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Network(string slug)
        {
            return View();
        }
    }
}