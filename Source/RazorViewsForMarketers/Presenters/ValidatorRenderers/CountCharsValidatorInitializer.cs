using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class CountCharsValidatorInitializer : ValidatorInitializerBase<CountCharsValidator>
    {
        public CountCharsValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, CountCharsValidator wffmValidator)
        {

        }

        public override void PopulateParameters(CountCharsValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(CountCharsValidator wffmValidator)
        {

        }
    }
}