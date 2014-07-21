using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public class TelephoneFieldInitializer : FieldInitializerBase<TelephoneField>
    {
        public TelephoneFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(TelephoneField field)
        {

        }

        public override void PopulateLocalizedParameters(TelephoneField field)
        {

        }
    }
}