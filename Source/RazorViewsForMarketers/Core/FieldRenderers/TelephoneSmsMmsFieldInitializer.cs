using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class TelephoneSmsMmsFieldInitializer : FieldInitializerBase<SmsMmsTelephoneField>
    {
        public TelephoneSmsMmsFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(SmsMmsTelephoneField field)
        {

        }

        public override void PopulateLocalizedParameters(SmsMmsTelephoneField field)
        {

        }
    }
}