using MMWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMWeb.Controllers
{
    [RoutePrefix("{lang:regex(en|ja|zh-hant)}")]
    [LanguageRedirectFilter]
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index(string lang)
        {
            // ① 写 Cookie 记住语言 1 年
            Response.Cookies.Add(new HttpCookie("lang", lang)
            { Expires = DateTime.Now.AddYears(1) });

            // ② 设置 <html lang="…">
            string htmlLang;
            switch (lang)
            {
                case "en":
                    htmlLang = "en";
                    break;
                case "ja":
                    htmlLang = "ja";
                    break;
                case "zh-hant":
                    htmlLang = "zh-Hant";
                    break;
                default:
                    htmlLang = "zh-CN";
                    break;
            }
            ViewBag.Lang = htmlLang;

            // ③ 根据语言返回对应视图，如 Views/Home/en.cshtml
            return View(lang);   // lang 即 "en" / "ja" / "zh-hant"
        }
    }
}