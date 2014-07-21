using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public class CheckBoxInitializer : FieldInitializerBase<CheckboxField>
    {
        public CheckBoxInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(CheckboxField field)
        {

        }

        public override void PopulateLocalizedParameters(CheckboxField field)
        {

        }
    }
}