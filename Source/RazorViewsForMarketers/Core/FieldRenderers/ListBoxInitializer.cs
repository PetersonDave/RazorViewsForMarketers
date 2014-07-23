using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class ListBoxInitializer : FieldInitializerBase<ListBoxField>
    {
        public ListBoxInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, ListBoxField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, ListBoxField model)
        {

        }
    }
}