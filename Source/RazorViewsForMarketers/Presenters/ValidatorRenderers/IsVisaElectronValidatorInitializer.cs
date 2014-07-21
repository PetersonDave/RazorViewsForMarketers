using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsVisaElectronValidatorInitializer : ValidatorInitializerBase<IsVisaElectronValidator>
    {
        public IsVisaElectronValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsVisaElectronValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsVisaElectronValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsVisaElectronValidator wffmValidator)
        {

        }
    }
}