using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsVisaValidatorInitializer : ValidatorInitializerBase<IsVisaValidator>
    {
        public IsVisaValidatorInitializer(Item fieldItem) : base(fieldItem) { }

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