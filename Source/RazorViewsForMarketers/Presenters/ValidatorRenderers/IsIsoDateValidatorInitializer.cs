using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsIsoDateValidatorInitializer : ValidatorInitializerBase<IsIsoDateValidator>
    {
        public IsIsoDateValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsIsoDateValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsIsoDateValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsIsoDateValidator wffmValidator)
        {

        }
    }
}