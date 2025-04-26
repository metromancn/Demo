using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexZhHant()
        {
            return View("Index.zh-hant");
        }

        public ActionResult IndexEn()
        {
            return View("Index.en");
        }

        public ActionResult IndexJa()
        {
            return View("Index.ja");
        }
    }
}