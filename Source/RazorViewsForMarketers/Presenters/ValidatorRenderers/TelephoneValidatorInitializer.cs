using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class TelephoneValidatorInitializer : ValidatorInitializerBase<TelephoneValidator>
    {
        public TelephoneValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, TelephoneValidator wffmValidator)
        {
            wffmValidator.ValidationExpression = validatorItem.Fields["Validation Expression"].Value;
        }

        public override void PopulateParameters(TelephoneValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(TelephoneValidator wffmValidator)
        {

        }
    }
}