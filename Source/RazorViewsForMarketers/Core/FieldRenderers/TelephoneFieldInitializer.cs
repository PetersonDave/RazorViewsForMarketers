using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class TelephoneFieldInitializer : FieldInitializerBase<TelephoneField>
    {
        public TelephoneFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, TelephoneField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, TelephoneField model)
        {

        }
    }
}