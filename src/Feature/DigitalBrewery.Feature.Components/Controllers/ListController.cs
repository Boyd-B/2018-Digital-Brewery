using System.Web.Mvc;
using Sitecore.XA.Feature.PageContent.Controllers;
using Sitecore.XA.Feature.PageContent.Repositories;
using DigitalBrewery.Feature.Components.Repositories;

namespace DigitalBrewery.Feature.Components.Controllers
{
    public class ListController : PageListController
    {
        public ListController(IComponentListRepository componentListRepository) : base(componentListRepository)
        {
        }

        public override ActionResult Index()
        {
            return List();
        }

        public ActionResult List()
        {
            return View("~\\Views\\Component\\List.cshtml", GetModel());
        }
    }
}