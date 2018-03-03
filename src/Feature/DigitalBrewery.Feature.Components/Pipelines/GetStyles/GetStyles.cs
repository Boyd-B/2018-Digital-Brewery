using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.XA.Foundation.Presentation;
using Sitecore.XA.Foundation.Presentation.Pipelines.GetStyles;
using Sitecore.XA.Foundation.SitecoreExtensions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DigitalBrewery.Feature.Components.Pipelines.GetStyles
{
    public class GetStyles : GetStylesProcessorBase
    {
        private readonly IPresentationContext PresentationContext;
        public readonly IContentRepository ContentRepository;
        private static readonly ID StylesTemplateId = new ID("C6DC7393-15BB-4CD7-B798-AB63E77EBAC4");

        public GetStyles(IPresentationContext presentationContext, IContentRepository contentRepository)
        {
            this.PresentationContext = presentationContext;
            this.ContentRepository = contentRepository;
        }

        public void Process(GetStylesArgs args)
        {
            if (string.IsNullOrEmpty(args.Rendering))
                return;

            ItemUri renderingItemUri = new ItemUri(args.Rendering);
            
            // Rendering represents component
            Item componentRendering = this.ContentRepository.GetItem(renderingItemUri.ItemID);
            
            // Get styles folder for the component
            Item styles = componentRendering?.Children.FirstOrDefault(item => item.TemplateID.Equals(StylesTemplateId));
            if (styles == null)
                return;
            
            args.Styles.AddRange(styles.Children);
        }
    }
}