using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class NumberRangeValidatorInitializer : ValidatorInitializerBase<NumberRangeValidator>
    {
        public NumberRangeValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, NumberRangeValidator wffmValidator)
        {

        }

        public override void PopulateParameters(NumberRangeValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(NumberRangeValidator wffmValidator)
        {

        }
    }
}