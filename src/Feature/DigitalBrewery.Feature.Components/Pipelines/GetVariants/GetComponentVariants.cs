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
            Item componentRendering = this.ContentRepository.GetItem(args.RenderingId);
            Item variants = componentRendering?.Children.FirstOrDefault(item => item.TemplateID.Equals(new Sitecore.Data.ID("E1A3B30C-77BC-4F6C-A008-D01B3371235D")));
            if (variants == null)
                return;

            args.Variants.AddRange(variants.Children);
        }
        
    }
}