using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMWeb.Controllers
{
    [RoutePrefix("en/cities/shanghai/lines")]
    public class LinesController : Controller
    {
        // GET /en/cities/shanghai/lines
        [HttpGet, Route("")]
        public ActionResult Index() => View();
    }
}