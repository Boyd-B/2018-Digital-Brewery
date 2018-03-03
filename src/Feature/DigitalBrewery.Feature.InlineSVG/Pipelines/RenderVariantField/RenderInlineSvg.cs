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
    public class RenderInlineSvg : Sitecore.XA.Foundation.RenderingVariants.Pipelines.RenderVariantField.RenderVariantField
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

            FileField mediaField = args.Item.Fields[variantField.ItemName];
            if (mediaField == null)
            {
                base.RenderField(args);
                return;
            }
            MediaItem mediaItem = mediaField.MediaItem;
            if (mediaItem == null || mediaItem.Extension != "svg")
            {
                base.RenderField(args);
                return;
            }

            args.ResultControl = (Control) new LiteralControl()
            {
                Text = GenerateSVGHtml(mediaItem)
            };
            args.Result = RenderControl(args.ResultControl);
        }


        protected virtual string GenerateSVGHtml(MediaItem svgItem)
        {
            using (StreamReader reader = new StreamReader(svgItem.GetMediaStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}