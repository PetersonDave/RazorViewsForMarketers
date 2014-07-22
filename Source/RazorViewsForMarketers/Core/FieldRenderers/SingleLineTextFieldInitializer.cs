using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class SingleLineTextFieldInitializer : FieldInitializerBase<SingleLineTextField>
    {
        public SingleLineTextFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(SingleLineTextField field)
        {

        }

        public override void PopulateLocalizedParameters(SingleLineTextField field)
        {

        }
    }
}