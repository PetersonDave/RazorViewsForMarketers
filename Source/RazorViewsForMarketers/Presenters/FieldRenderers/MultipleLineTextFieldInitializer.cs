using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public class MultipleLineTextFieldInitializer : FieldInitializerBase<MultipleLineTextField>
    {
        public MultipleLineTextFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(MultipleLineTextField field)
        {

        }

        public override void PopulateLocalizedParameters(MultipleLineTextField field)
        {

        }
    }
}