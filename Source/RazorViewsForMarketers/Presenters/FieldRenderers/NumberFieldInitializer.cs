using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public class NumberFieldInitializer : FieldInitializerBase<NumberField>
    {
        public NumberFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(NumberField field)
        {

        }

        public override void PopulateLocalizedParameters(NumberField field)
        {

        }
    }
}