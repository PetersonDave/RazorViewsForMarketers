using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class CaptchaInitializer : FieldInitializerBase<CaptchaField>
    {
        public CaptchaInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, CaptchaField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, CaptchaField model)
        {

        }
    }
}