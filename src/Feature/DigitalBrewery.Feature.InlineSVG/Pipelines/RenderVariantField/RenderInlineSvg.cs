using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Helpers;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;

namespace DigitalBrewery.Feature.InlineSVG.Pipelines.RenderVariantField
{
    public class RenderInlineSvg : RenderVariantFieldProcessor
    {
        public override Type SupportedType
        {
            get
            {
                return typeof(Sitecore.XA.Foundation.RenderingVariants.Fields.VariantField);
            }
        }

        public override RendererMode RendererMode
        {
            get
            {
                return RendererMode.Html;
            }
        }

        public override void RenderField(RenderVariantFieldArgs args)
        {

            Sitecore.XA.Foundation.RenderingVariants.Fields.VariantField variantField = args.VariantField as Sitecore.XA.Foundation.RenderingVariants.Fields.VariantField;
            if (variantField == null)
                return;

            args.ResultControl = (Control)new LiteralControl()
            {
                Text = GenerateSVGHtml(args)
            };
            args.Result = RenderControl(args.ResultControl);
        }


        protected virtual string GenerateSVGHtml(RenderVariantFieldArgs args)
        {
            FileField mediaField = args.Item.Fields[args.VariantField.ItemName];
            if (mediaField == null)
                return null;
            MediaItem mediaItem = mediaField.MediaItem;
            using (StreamReader reader = new StreamReader(mediaItem.GetMediaStream()))
            {
                return reader.ReadToEnd();
            }
        }

    }
}