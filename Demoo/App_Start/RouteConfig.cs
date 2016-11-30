using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demoo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Ustawienia routingu. Domyślnie url jest interpretowany tak jak ustawione to zostało w ponizszych linijkach:
            // adres/kontroler/akcja/parametrOpcjonalny
            // Domyślnie na start, jak i w momencie braku podania żadnych parametrów po adresie, aplikacja przyjmie, że żądanie ma być obsłużone przez akcję Index kontrolera Home.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
