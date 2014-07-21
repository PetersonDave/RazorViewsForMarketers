using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class NumberValidatorInitializer : ValidatorInitializerBase<NumberValidator>
    {
        public NumberValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, NumberValidator wffmValidator)
        {
            wffmValidator.ValidationExpression = validatorItem.Fields["Validation Expression"].Value;
        }

        public override void PopulateParameters(NumberValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(NumberValidator wffmValidator)
        {

        }
    }
}