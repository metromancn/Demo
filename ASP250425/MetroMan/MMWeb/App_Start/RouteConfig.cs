using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MMWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 多语言主页独立路由
            routes.MapRoute(
                name: "HomeZhHant",
                url: "zh-hant",
                defaults: new { controller = "Home", action = "IndexZhHant" }
            );
            routes.MapRoute(
                name: "HomeEn",
                url: "en",
                defaults: new { controller = "Home", action = "IndexEn" }
            );
            routes.MapRoute(
                name: "HomeJa",
                url: "ja",
                defaults: new { controller = "Home", action = "IndexJa" }
            );
            // 默认简体主页
            routes.MapRoute(
                name: "DefaultHome",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );
            // 其它页面动态多语言
            routes.MapRoute(
                name: "LocalizedDefault",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { lang = UrlParameter.Optional, controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = "zh-hant|en|ja" }
            );
            // 默认其它页面
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
