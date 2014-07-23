using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class MultipleLineTextFieldInitializer : FieldInitializerBase<MultipleLineTextField>
    {
        public MultipleLineTextFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, MultipleLineTextField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, MultipleLineTextField model)
        {

        }
    }
}