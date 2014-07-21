using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsSwitchValidatorInitializer : ValidatorInitializerBase<IsSwitchValidator>
    {
        public IsSwitchValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsSwitchValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsSwitchValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsSwitchValidator wffmValidator)
        {

        }
    }
}