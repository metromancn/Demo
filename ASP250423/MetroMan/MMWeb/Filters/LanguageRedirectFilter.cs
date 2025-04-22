using System.Linq;
using System.Web.Mvc;

namespace MMWeb.Filters
{
    public class LanguageRedirectFilter : ActionFilterAttribute
    {
        private static readonly string[] langs = { "", "en", "ja", "zh-hant" };

        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            var req = ctx.HttpContext.Request;
            var currentLang = (ctx.RouteData.Values["lang"] ?? "").ToString().ToLower();

            // 已在 /en /ja /zh-hant → 不再跳转
            if (langs.Skip(1).Contains(currentLang)) return;

            // 1) Cookie 优先
            string cookieLang = (req.Cookies["lang"]?.Value ?? "").ToLower();
            if (langs.Skip(1).Contains(cookieLang))
            {
                ctx.Result = Redirect(cookieLang, req.RawUrl);
                return;
            }

            // 2) Accept-Language
            string al = req.UserLanguages?.FirstOrDefault()?.ToLower() ?? "";
            if (al.StartsWith("ja")) { ctx.Result = Redirect("ja", req.RawUrl); return; }
            if (al.StartsWith("en")) { ctx.Result = Redirect("en", req.RawUrl); return; }
            if (al.StartsWith("zh-hant") ||
                al.StartsWith("zh-tw") ||
                al.StartsWith("zh-hk")) { ctx.Result = Redirect("zh-hant", req.RawUrl); return; }

            // 3) 默认留在简体根目录
        }

        private RedirectResult Redirect(string lang, string rawUrl)
        {
            var target = "/" + lang + (rawUrl == "/" ? "/" : rawUrl);
            return new RedirectResult(target, false);   // 302
        }
    }
}