using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsJcbValidatorInitializer : ValidatorInitializerBase<IsJcbValidator>
    {
        public IsJcbValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsJcbValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsJcbValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsJcbValidator wffmValidator)
        {

        }
    }
}