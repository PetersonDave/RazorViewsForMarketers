using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class ListBoxInitializer : FieldInitializerBase<ListBoxField>
    {
        public ListBoxInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(ListBoxField field)
        {

        }

        public override void PopulateLocalizedParameters(ListBoxField field)
        {

        }
    }
}