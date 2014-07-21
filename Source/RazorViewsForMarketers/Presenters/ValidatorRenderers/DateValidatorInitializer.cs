using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class DateValidatorInitializer : ValidatorInitializerBase<DateValidator>
    {
        public DateValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, DateValidator wffmValidator)
        {

        }

        public override void PopulateParameters(DateValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(DateValidator wffmValidator)
        {

        }
    }
}