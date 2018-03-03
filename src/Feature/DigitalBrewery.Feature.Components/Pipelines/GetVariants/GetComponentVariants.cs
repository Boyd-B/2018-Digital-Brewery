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
        private static readonly Sitecore.Data.ID VariantsTemplateId = new Sitecore.Data.ID("E1A3B30C-77BC-4F6C-A008-D01B3371235D");

        public readonly IContentRepository ContentRepository;
        
        public GetComponentVariants(IContentRepository contentRepository)
        {
            this.ContentRepository = contentRepository;
        }

        public void Process(GetVariantsArgs args)
        {
            // Rendering represents component
            Item componentRendering = this.ContentRepository.GetItem(args.RenderingId);
            
            // Get variants template folder that contains component variants
            Item variants = componentRendering?.Children.FirstOrDefault(item => item.TemplateID.Equals(VariantsTemplateId));
            if (variants == null)
                return;

            args.Variants.AddRange(variants.Children);
        }
    }
}