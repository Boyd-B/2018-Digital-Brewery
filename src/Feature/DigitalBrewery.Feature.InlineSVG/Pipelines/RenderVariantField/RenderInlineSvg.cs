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
            
            FileField fileField = args.Item.Fields[variantField.ItemName];
            // If not a file field, continue with normal processing
            if (fileField == null)
            {
                base.RenderField(args);
                return;
            }
            
            MediaItem mediaItem = fileField.MediaItem;
            // Get media item from file field, check for svg
            if (mediaItem == null || mediaItem.Extension != "svg")
            {
                base.RenderField(args);
                return;
            }

            args.ResultControl = new LiteralControl()
            {
                Text = GenerateSvgHtml(mediaItem)
            };
            args.Result = RenderControl(args.ResultControl);
        }

        protected virtual string GenerateSvgHtml(MediaItem svgItem)
        {
            // Svg is an xml file, so it can be read like any other text file.
            using (StreamReader reader = new StreamReader(svgItem.GetMediaStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}