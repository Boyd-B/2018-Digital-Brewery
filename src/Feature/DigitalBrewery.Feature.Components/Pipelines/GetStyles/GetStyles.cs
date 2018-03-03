using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.XA.Foundation.Multisite;
using Sitecore.XA.Foundation.Presentation;
using Sitecore.XA.Foundation.Presentation.Pipelines.GetStyles;
using Sitecore.XA.Foundation.SitecoreExtensions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DigitalBrewery.Feature.Components.Pipelines.GetStyles
{
    //public class GetStyles : GetStylesProcessorBase
    //{
    //    private readonly ISharedSitesContext _sharedSiteContext;
    //    private readonly IPresentationContext _presentationContext;
    //    private readonly IMultisiteContext _multisiteContext;

    //    public GetStyles(ISharedSitesContext sharedSiteContext, IPresentationContext presentationContext, IMultisiteContext multisiteContext)
    //    {
    //        this._sharedSiteContext = sharedSiteContext;
    //        this._presentationContext = presentationContext;
    //        this._multisiteContext = multisiteContext;
    //    }

    //    public void Process(GetStylesArgs args)
    //    {
    //        if (this._sharedSiteContext == null || this._presentationContext == null || this._multisiteContext == null)
    //            return;
    //        ItemUri renderingItemUri = new ItemUri(args.Rendering);
    //        foreach (Item obj in this._sharedSiteContext.GetSharedSitesWithoutCurrent(args.ContextItem))
    //        {
    //            Item stylesItem = this._presentationContext.GetStylesItem(obj);
    //            if (stylesItem != null)
    //                args.Styles.AddRange((IEnumerable<Item>)((IEnumerable<Item>)stylesItem.Axes.GetDescendants()).Where<Item>((Func<Item, bool>)(i =>
    //                {
    //                    if (this.IsStyleItem(i))
    //                        return this.IsAllowed(i, renderingItemUri);
    //                    return false;
    //                })).ToArray<Item>());
    //        }
    //    }
    //}

    public class GetStyles : GetStylesProcessorBase
    {
        private readonly IPresentationContext PresentationContext;
        public readonly IContentRepository ContentRepository;

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

            Item stylesItem = this.PresentationContext.GetStylesItem(args.ContextItem);
            if (stylesItem == null)
                return;

            Item obj1 = this.ContentRepository.GetItem(new Sitecore.Data.ID("34AAF817-5505-4549-BE92-C548D7AF2E9E"));

            foreach(var item in obj1.Axes.GetDescendants())
            {
                if (this.IsStyleItem(item) )//&& this.IsAllowed(item, renderingItemUri))
                    args.Styles.Add(item);
            }

            //args.Styles.AddRange((IEnumerable<Item>)((IEnumerable<Item>)obj1.Axes.GetDescendants()).Where<Item>((Func<Item, bool>)(i =>
            //{
            //    if (this.IsStyleItem(i))
            //        return this.IsAllowed(i, renderingItemUri);
            //    return false;
            //})).ToArray<Item>());
        }
    }
}