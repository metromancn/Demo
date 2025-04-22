using System;
using System.Web;
using System.Web.Mvc;

namespace MMWeb.Controllers           // ← 按你的根命名空间
{
    public class LangController : Controller
    {
        //  /setlang?to=en&return=/cities/shanghai
        [HttpGet]
        public ActionResult SetLang(string to = "zh", string @return = "/")
        {
            // ── 1) 写或清除 cookie ─────────────────────
            if (to == "zh")           // 简体 ⇒ 删除 cookie
            {
                Response.Cookies.Add(new HttpCookie("lang") { Expires = DateTime.Now.AddYears(-1) });
            }
            else if (to == "en" || to == "ja" || to == "zh-hant")
            {
                Response.Cookies.Add(new HttpCookie("lang", to)
                {
                    Expires = DateTime.Now.AddYears(1),
                    Path = "/",
                    SameSite = SameSiteMode.Lax   // 兼容现代浏览器
                });
            }
            else                       // 兜底
            {
                to = "zh";
            }

            // ── 2) 计算目标 URL ───────────────────────
            string target = @return;
            if (to == "zh")
            {
                // 去掉任何语言前缀
                target = RemoveLangPrefix(@return);
            }
            else
            {
                target = "/" + to + RemoveLangPrefix(@return);
            }

            return Redirect(target);
        }

        private static string RemoveLangPrefix(string url)
        {
            if (string.IsNullOrEmpty(url) || url == "/") return "/";
            string[] langs = { "/en/", "/ja/", "/zh-hant/" };
            foreach (var l in langs)
                if (url.StartsWith(l, StringComparison.OrdinalIgnoreCase))
                    return url.Substring(l.Length - 1);   // 保留开头 /
            return url;
        }
    }
}
