using System.Web.Mvc;
using Sitecore.XA.Foundation.RenderingVariants.Controllers;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using DigitalBrewery.Feature.Components.Repositories;

namespace DigitalBrewery.Feature.Components.Controllers
{
    public class ComponentController : VariantsController
    {
        public ComponentController()
        {
        }

        public ComponentController(IComponentRepository variantsRepository) : base(variantsRepository)
        {
        }

        public override ActionResult Index()
        {
            return Item();
        }

        public ActionResult Item()
        {
            return View("~\\Views\\Component\\Item.cshtml", GetModel());
        }
    }
}