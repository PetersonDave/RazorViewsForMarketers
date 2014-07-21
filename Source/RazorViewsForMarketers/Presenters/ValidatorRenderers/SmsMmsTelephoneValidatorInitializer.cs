using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class SmsMmsTelephoneValidatorInitializer : ValidatorInitializerBase<SmsMmsTelephoneValidator>
    {
        public SmsMmsTelephoneValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, SmsMmsTelephoneValidator wffmValidator)
        {
            wffmValidator.ValidationExpression = validatorItem.Fields["Validation Expression"].Value;
        }

        public override void PopulateParameters(SmsMmsTelephoneValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(SmsMmsTelephoneValidator wffmValidator)
        {

        }
    }
}