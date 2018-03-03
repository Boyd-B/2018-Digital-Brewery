using Sitecore.Data.Items;
using Sitecore.XA.Foundation.SitecoreExtensions.Repositories;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.GetVariants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalBrewery.Feature.Components.Pipelines.GetVariants
{
    public class GetComponentVariants
    {
        public readonly IContentRepository ContentRepository;
        
        public GetComponentVariants(IContentRepository contentRepository)
        {
            this.ContentRepository = contentRepository;
        }

        public void Process(GetVariantsArgs args)
        {
            Item obj1 = this.ContentRepository.GetItem(new Sitecore.Data.ID("34AAF817-5505-4549-BE92-C548D7AF2E9E"));
            Item obj2 = obj1 != null ? obj1.Children.FirstOrDefault<Item>((Func<Item, bool>)(item => item.Name.Equals(args.RenderingName))) : (Item)null;
            if (obj2 == null)
                return;
            Item obj3 = obj2.Children.FirstOrDefault<Item>((Func<Item, bool>)(item => item.TemplateID.Equals(new Sitecore.Data.ID("E1A3B30C-77BC-4F6C-A008-D01B3371235D"))));
            if (obj3 == null)
                return;
            args.Variants.AddRange((IEnumerable<Item>)obj3.Children);
        }
        
    }
}