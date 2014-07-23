using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using CheckboxField = RazorViewsForMarketers.Models.Fields.CheckboxField;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class CheckBoxInitializer : FieldInitializerBase<CheckboxField>
    {
        public CheckBoxInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, CheckboxField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, CheckboxField model)
        {

        }
    }
}