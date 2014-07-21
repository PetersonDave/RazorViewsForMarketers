using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class CaptchaValidatorInitializer : ValidatorInitializerBase<CaptchaValidator>
    {
        public CaptchaValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, CaptchaValidator wffmValidator)
        {

        }

        public override void PopulateParameters(CaptchaValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(CaptchaValidator wffmValidator)
        {

        }
    }
}