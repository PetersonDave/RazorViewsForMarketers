using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsVisaInitializer : ValidatorInitializerBase<IsVisaValidator>
    {
        public IsVisaInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsVisaValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsVisaValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsVisaValidator wffmValidator)
        {

        }
    }
}