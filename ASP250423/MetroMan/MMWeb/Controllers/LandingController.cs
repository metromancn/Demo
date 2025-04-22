using MMWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMWeb.Controllers
{
    [LanguageRedirectFilter]          // ← 根目录自动跳转
    public class LandingController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Lang = "zh-CN";
            return View();
        }
    }
}