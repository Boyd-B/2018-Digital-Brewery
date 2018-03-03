using Sitecore.Pipelines;
using System.Web.Routing;

namespace DigitalBrewery.Feature.AssetEditor.Pipelines.MVC
{
    public class ApplicationStart
    {
        public void Process(PipelineArgs args)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}