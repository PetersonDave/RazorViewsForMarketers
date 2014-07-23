using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class NumberFieldInitializer : FieldInitializerBase<NumberField>
    {
        public NumberFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, NumberField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, NumberField model)
        {

        }
    }
}