using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMWeb.Controllers
{
    [RoutePrefix("en/cities/shanghai")]
    public class ShanghaiController : Controller
    {
        // GET /en/cities/shanghai
        [HttpGet, Route("")]
        public ActionResult Index() => View();

        // GET /en/cities/shanghai/metro-map
        [HttpGet, Route("metro-map")]
        public ActionResult MetroMap() => View();

        // GET /en/cities/shanghai/planning-map
        [HttpGet, Route("planning-map")]
        public ActionResult PlanningMap() => View();
    }
}