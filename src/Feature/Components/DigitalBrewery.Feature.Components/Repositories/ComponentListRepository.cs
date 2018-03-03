using System.Linq;
using Sitecore.XA.Feature.PageContent.Repositories;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Lists.Pagination;
using Sitecore.XA.Foundation.RenderingVariants.Models;


namespace DigitalBrewery.Feature.Components.Repositories
{
    public class ComponentListRepository : PageListRepository, IComponentListRepository
    {
        public IRenderingModelBase GetModel(IListPagination paginationConfiguration)
        {
            VariantListsRenderingModel listsRenderingModel = new VariantListsRenderingModel();
            this.FillBaseProperties((object)listsRenderingModel);
            listsRenderingModel.Items = this.Items.Where(x => x.ID != this.CurrentItem.ID).Skip(paginationConfiguration.Skip).Take(paginationConfiguration.PageSize);
            return (IRenderingModelBase)listsRenderingModel;
        }
    }
}