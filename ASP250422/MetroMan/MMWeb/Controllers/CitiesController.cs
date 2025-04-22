using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMWeb.Controllers
{
    [RoutePrefix("en/cities")]
    public class CitiesController : Controller
    {
        // GET /en/cities
        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}