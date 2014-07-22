using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class CaptchaInitializer : FieldInitializerBase<CaptchaField>
    {
        public CaptchaInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(CaptchaField field)
        {

        }

        public override void PopulateLocalizedParameters(CaptchaField field)
        {

        }
    }
}