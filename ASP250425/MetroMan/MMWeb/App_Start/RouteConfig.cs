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

            routes.MapRoute(
                name: "RankingZhHant",
                url: "zh-hant/ranking",
                defaults: new { controller = "Ranking", action = "Index" }
            );
            routes.MapRoute(
                name: "RankingEn",
                url: "en/ranking",
                defaults: new { controller = "Ranking", action = "Index" }
            );
            routes.MapRoute(
                name: "RankingJa",
                url: "ja/ranking",
                defaults: new { controller = "Ranking", action = "Index" }
            );
            routes.MapRoute(
                name: "RankingDefault",
                url: "ranking",
                defaults: new { controller = "Ranking", action = "Index" }
            );

            routes.MapRoute(
                name: "City",
                url: "cities/{slug}",
                defaults: new { controller = "Cities", action = "Detail" }
            );
            routes.MapRoute(
                name: "Cities",
                url: "cities",
                defaults: new { controller = "Cities", action = "Index" }
            );
            routes.MapRoute(
                name: "StationDetail",
                url: "cities/{city}/stations/{station}",
                defaults: new { controller = "Stations", action = "Detail" }
            );

            routes.MapRoute(
                name: "NetworkMap",
                url: "maps/network/{slug}",
                defaults: new { controller = "Maps", action = "Network" }
            );

            routes.MapRoute(
                name: "DefaultHome",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "LocalizedDefault",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { lang = UrlParameter.Optional, controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = "zh-hant|en|ja" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
