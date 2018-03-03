using System.Web.Mvc;
using System.Web.Routing;

namespace DigitalBrewery.Feature.AssetEditor.Pipelines.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("GetProperty", "api/sitecore/Property/GetProperty", new { controller = "PropertyController", action = "GetProperty" });
        }
    }
}