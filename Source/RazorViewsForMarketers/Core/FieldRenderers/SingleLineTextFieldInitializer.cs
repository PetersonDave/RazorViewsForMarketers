using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class SingleLineTextFieldInitializer : FieldInitializerBase<SingleLineTextField>
    {
        public SingleLineTextFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, SingleLineTextField model)
        {
            // Logic here to parse "Parameters" field of WFFM field item
        }

        public override void PopulateLocalizedParameters(Field field, SingleLineTextField model)
        {
            // Logic here to parse "Localized Parameters" field of WFFM field item
        }
    }
}