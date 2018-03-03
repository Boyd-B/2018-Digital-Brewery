using System.Collections.Generic;
using System.Linq;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using Sitecore.XA.Foundation.Variants.Abstractions.Fields;

namespace DigitalBrewery.Feature.Components.Repositories
{
    public class ComponentRepository : VariantsRepository, IComponentRepository
    {
        protected override int PrepareVariantPlaceholders(List<BaseVariantField> variantFields, int variantPlaceholderNumber = 1)
        {
            //return base.PrepareVariantPlaceholders(variantFields, variantPlaceholderNumber);

            foreach (BaseVariantField variantField in variantFields)
            {
                if (variantField is Sitecore.XA.Foundation.RenderingVariants.Fields.VariantPlaceholder)
                {
                    Sitecore.XA.Foundation.RenderingVariants.Fields.VariantPlaceholder variantPlaceholder = variantField as Sitecore.XA.Foundation.RenderingVariants.Fields.VariantPlaceholder;
                    string parameter = this.Rendering.RenderingId.ToString();
                    variantPlaceholder.DynamicPlaceholderId = parameter;
                    string name = this.Rendering.Name;
                    variantPlaceholder.RenderingName = name;
                    int num = variantPlaceholderNumber;
                    variantPlaceholder.Number = num;
                    ++variantPlaceholderNumber;
                }
                else if (variantField is Sitecore.XA.Foundation.RenderingVariants.Fields.VariantSection)
                {
                    Sitecore.XA.Foundation.RenderingVariants.Fields.VariantSection variantSection = variantField as Sitecore.XA.Foundation.RenderingVariants.Fields.VariantSection;
                    List<BaseVariantField> list = variantSection.SectionFields.ToList<BaseVariantField>();
                    variantPlaceholderNumber = this.PrepareVariantPlaceholders(list, variantPlaceholderNumber);
                    List<BaseVariantField> baseVariantFieldList = list;
                    variantSection.SectionFields = (IEnumerable<BaseVariantField>)baseVariantFieldList;
                }
            }
            return variantPlaceholderNumber;
        }
    }
}