using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class TelephoneSmsMmsFieldInitializer : FieldInitializerBase<SmsMmsTelephoneField>
    {
        public TelephoneSmsMmsFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, SmsMmsTelephoneField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, SmsMmsTelephoneField model)
        {

        }
    }
}